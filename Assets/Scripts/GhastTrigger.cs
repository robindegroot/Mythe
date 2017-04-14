using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhastTrigger : MonoBehaviour
{

    private AudioSource source;
    public AudioClip Scream;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("booooh");
            source.PlayOneShot(Scream);

        }
    }
}
