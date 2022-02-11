using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;
    private static AudioPlayerManager instance = null;
    private AudioSource audioSrc;
    private int audioID;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioID = Random.Range(0, 2);
        print(audioID);
        audioSrc.clip = songs[audioID];
        
        audioSrc.Play();
    }
}
