using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bathroom : MonoBehaviour
{
    [SerializeField] private RectTransform canvas, buttonPrompt;
    private GameObject promptPrefab;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        promptPrefab = Instantiate(buttonPrompt.gameObject, canvas);

        Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
        texts[0].text = "E";
        texts[1].text = "Use the washroom";
        promptPrefab.transform.position = gameObject.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && Input.GetKeyDown(KeyCode.E))
            Debug.Log("Blood cleaned");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(promptPrefab);
    }
}
