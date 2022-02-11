using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum SanityDisplay
{
    Zero, Ten, Twenty, Thirty, Forty, Fifty, Sixty, Seventy, Eighty, Ninety, Full
}

public class InsanityEffects : MonoBehaviour
{       
    private SanityDisplay sanityDisplay;
    [SerializeField] private List<Image> sanityImage;

    void Start()
    {       
        sanityDisplay = new SanityDisplay();
    }

    public void ChangeSanity(int sanity)
    {
        if (sanity == 100)
        {
            sanityDisplay = SanityDisplay.Full;
        }
        else if (sanity >= 90)
        {
            sanityDisplay = SanityDisplay.Ninety;
        }
        else if (sanity >= 80)
        {
            sanityDisplay = SanityDisplay.Eighty;
        }
        else if (sanity >= 70)
        {
            sanityDisplay = SanityDisplay.Seventy;
        }
        else if (sanity >= 60)
        {
            sanityDisplay = SanityDisplay.Sixty;
        }
        else if (sanity >= 50)
        {
            sanityDisplay = SanityDisplay.Fifty;
        }
        else if (sanity >= 40)
        {
            sanityDisplay = SanityDisplay.Forty;
        }
        else if (sanity >= 30)
        {
            sanityDisplay = SanityDisplay.Thirty;
        }
        else if (sanity >= 20)
        {
            sanityDisplay = SanityDisplay.Twenty;
        }
        else if (sanity >= 10)
        {
            sanityDisplay = SanityDisplay.Ten;
        }
        else
        {
            sanityDisplay = SanityDisplay.Zero;
        }
        switch (sanityDisplay)
        {
            case SanityDisplay.Zero:
                sanityImage[0].gameObject.SetActive(true);
                break;
            case SanityDisplay.Ten:
                sanityImage[1].gameObject.SetActive(true);
                break;
            case SanityDisplay.Twenty:
                sanityImage[2].gameObject.SetActive(true);
                break;
            case SanityDisplay.Thirty:
                sanityImage[3].gameObject.SetActive(true);
                break;
            case SanityDisplay.Forty:
                sanityImage[4].gameObject.SetActive(true);
                break;
            case SanityDisplay.Fifty:
                sanityImage[5].gameObject.SetActive(true);
                break;
            case SanityDisplay.Sixty:
                sanityImage[6].gameObject.SetActive(true);
                break;
            case SanityDisplay.Seventy:
                sanityImage[7].gameObject.SetActive(true);
                break;
            case SanityDisplay.Eighty:
                sanityImage[8].gameObject.SetActive(true);
                break;
            case SanityDisplay.Ninety:
                sanityImage[9].gameObject.SetActive(true);
                break;
            case SanityDisplay.Full:
                sanityImage[10].gameObject.SetActive(true);
                break;
        }
    }
}
