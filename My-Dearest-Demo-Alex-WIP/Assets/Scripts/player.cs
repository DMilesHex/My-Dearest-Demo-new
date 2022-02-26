using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public delegate void OnMoneyChanged(float amount);
    public static event OnMoneyChanged MoneyChanged;

    #region Variables
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 movement;

    [Space(2)]
    [Header("Sanity")]
    public int Sanity;
    public int SanityMax = 100;

    [Space(2)]
    [Header("Inventory")]
    [SerializeField]
    public Weapon[] weapons;
    public GameObject weaponheld;
    public InventoryScript inventory;

    [Space(2)]
    [Header("Study points")]
    public int studyPoints;

    [Space(2)]
    [Header("Dialogue")]
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueActivator dialogueActivator;
    public DialogueUI DialogueUI => dialogueUI;

    [Space(2)]
    [Header("UI")]
    [SerializeField] private Button button;
    [SerializeField] private Button button2;
    [SerializeField] private GameObject responseContainer, secondResponseContainer;
    [SerializeField] private Image panelColour;
    [SerializeField] private GameObject canvas;
    [SerializeField] private RectTransform buttonCanvas, buttonPrompt;

    [Space(2)]
    [Header("I can't name this section")]
    public bool chopped;
    Weapon axe;
    public TimeCycle tc;
    public UnityEvent tutor;
    public GameObject tutorButtons;
    public bool litter;
    public UnityEvent loadBar;
    public InsanityEffects ie;
    public int repIncrease;
    public bool canGainRep = true;
    public I_Interactable interactable { get; set; }
    public AddPoints add;
    public int psych, bio;
    public List<UnityEvent> win;
    public List<UnityEvent> questComplete;

    //Private variables
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject promptPrefab;

    [SerializeField] private GameObject rival;
    #endregion

    public void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        inventory = GameObject.FindWithTag("Inventory").GetComponent<InventoryScript>();
        Sanity = SanityMax;
    }

    public void Equip(int equipnumber)
    {
        Debug.Log("equipped");
        Weapon weapontoequip = inventory.InventoryList[equipnumber];
        weaponheld = weapontoequip.weaponprefab;
    }

 
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Outside")
        {
            weapons = Resources.FindObjectsOfTypeAll<Weapon>();

            promptPrefab = Instantiate(buttonPrompt.gameObject, buttonCanvas);

            Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
            texts[0].text = "E";
            texts[1].text = "Tutor";
            promptPrefab.transform.position = gameObject.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 0)
            return;
        else
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (!SceneManager.GetActiveScene().name.Equals("House"))
            ie.ChangeSanity(Sanity);
        else
        {
            button.interactable = studyPoints > 0;
            button2.interactable = dialogueActivator.Rep > 20;
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale > 0)
            interactable?.Interact(this);

        if (SceneManager.GetActiveScene().name == "Outside")
        {
            if (Input.GetKey(KeyCode.E) && tc.hours > 16)
            {
                tutorButtons.SetActive(true);
                tc.hours += 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                litter = true;
                dialogueActivator.Pop -= 5;
            }
        }
        if (dialogueActivator != null)
        {
            if (dialogueActivator.Rep >= 100)
            {
                win[1].Invoke();
            }
            if (dialogueActivator.Pop <= -10)
            {
                win[2].Invoke();
            }
        }

        if (!rival.activeSelf)
        {
            win[3].Invoke();
        }
    }

    void FixedUpdate() => MoveCharacter(movement);    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon.weaponType == Weapon.WeaponType.Axe)
                axe = weapon;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {       
        if (collision.CompareTag("Tree") && axe.equipped && Input.GetKeyDown(KeyCode.F))
        {
            chopped = true;
            anim.SetBool("isChopped", true);
        }
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    public void AddStudyPoints(int amount) => studyPoints += amount; 
    public void ExtraRepPoints() => repIncrease = 5;
    public void SanityRestore() => Sanity = SanityMax;
    public void MakeMoney()
    {
        responseContainer.SetActive(false);
        secondResponseContainer.SetActive(true);
    }

    public void Tutor()
    {
        MoneyChanged(100);
        EndDay();
    }

    public void Job()
    {
        MoneyChanged(30);
        EndDay();
    }

    public void Shady()
    {
        float troubleChance = Random.value;
        if (troubleChance > 0.3)
        {
            MoneyChanged(50);
            return;
        }
        else if (troubleChance < 0.05)
        {
            Debug.Log("You were arrested. Game over");
            return;
        }
        else
        {
            canGainRep = false;
        }

        EndDay();
    }

    public void Invite()
    {
        win[0].Invoke();
        
    }

    public void StatDist(int index)
    {
        if (studyPoints < 0)
            return;

        studyPoints--;
        switch (index)
        {
            case 0:
                psych++;
                break;
            case 1:
                bio++;
                break;
        }
        add.Add(index);
    }

    void EndDay()
    {
        canvas.SetActive(false);
        Color32 tempColour = panelColour.color;
        Color32 endColour = panelColour.color;
        endColour.a = 255;
        tempColour = Color32.Lerp(panelColour.color, endColour, Time.time);
        panelColour.color = tempColour;
        Color32 fadein = panelColour.color;
        fadein.a = 0;
        tempColour = Color32.Lerp(panelColour.color, fadein, Time.time);
        panelColour.color = tempColour;
        loadBar.Invoke();
    }

    public void QuestChecks()
    {
        if (tc.hours == 7 && SceneManager.GetActiveScene().name == "Pool")
        {
            questComplete[0].Invoke();
        }

        if (tc.hours == 1 && tc.minutes == 30 
            && SceneManager.GetActiveScene().name == "Third Floor Hallway")
        {
            questComplete[1].Invoke();
        }

        if (tc.hours == 7 && tc.minutes == 30
       && SceneManager.GetActiveScene().name == "SampleScene")
        {
            questComplete[2].Invoke();
        }
    }

}
