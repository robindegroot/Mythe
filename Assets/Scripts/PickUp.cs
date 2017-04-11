using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PickUp : MonoBehaviour {

    [SerializeField]
    private Text pickUpText;
    private bool pickedUp = true;
    private bool hintSound = true;
    private float waitTime = 10f;

    [SerializeField]
    private string objectName = "";

    public AudioClip clip;

	// Use this for initialization
	void Start () {
        pickUpText.enabled = false;
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            pickUpText.enabled = true;
        if (pickedUp == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            pickUpText.enabled = false;
            //Inventory.add(objectName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            pickUpText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hintSound)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, 0.01f);
            StartCoroutine("HintSoundCooldown");
        }
    }

    IEnumerator HintSoundCooldown()
    {
        hintSound = false;
        yield return new WaitForSeconds(waitTime);
        hintSound = true;
    }
}
