using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundSFX : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioSource audioSource1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SelectionSoundSFX()
    {
        audioSource.Play();
    }

    public void SeletedSoundSFX()
    {
        audioSource1.Play();
    }
}
