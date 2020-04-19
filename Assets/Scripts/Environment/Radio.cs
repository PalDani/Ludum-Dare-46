using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Radio : MonoBehaviour
{

    public AudioSource audioSrc;
    public TMPro.TMP_Text statusText;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = true;
        audioSrc.Play();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        if (isPlaying)
        {
            audioSrc.Stop();
            statusText.text = "Music: OFF";
        }
        else
        {
            audioSrc.Play();
            statusText.text = "Music: ON";
        }
        isPlaying = !isPlaying;
    }
}
