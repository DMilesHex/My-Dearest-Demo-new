using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float typeWriterSpeed = 50f;
    public bool isRunning { get; private set; }
    private readonly List<Punctuation> punctuations = new List<Punctuation>()
    {
        new Punctuation(new HashSet<char>(){'.', '?', '!'}, 0.6f),
        new Punctuation(new HashSet<char>(){',', ';', ':'}, 0.3f),
        
    };

    

    public Coroutine Run(DialogueLine textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }



    private IEnumerator TypeText(DialogueLine textToType, TMP_Text textLabel)
    {
        isRunning = true;
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.LineText.Length)
        {
            int lastCharIndex = charIndex;
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.LineText.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.LineText.Length - 1;
                textLabel.text = textToType.LineText.Substring(0, i+1);

                if (IsPunctuation(textToType.LineText[i], out float waitTime) && !isLast && !IsPunctuation(textToType.LineText[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }
            

            yield return null;
            
        }
        
        
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime;
                return true;
            }
        }
        waitTime = default;
        return false;
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }
}
