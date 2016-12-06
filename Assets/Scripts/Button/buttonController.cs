using UnityEngine;
using System.Collections;

public class buttonController : MonoBehaviour {
    private Light lt;
    private AudioSource audioclip;
    private float counter;
    public GameObject door;

    // Use this for initialization
    void Start () {
        counter = 0;
        lt = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (counter == 0) { 
            var target_object_ref = transform.parent.gameObject;
            var target_object_anim = target_object_ref.GetComponent<Animation>();
            target_object_anim.Play("godown");
            lt.intensity = 2;
            audioclip = GetComponent<AudioSource>();
            audioclip.Play();
            door.GetComponent<doorController>().buttonsPressed++;
            door.SendMessage("RecieveData");
        }
        counter = (counter + 1);
    }

    void OnTriggerExit(Collider other)
    {
        counter = (counter - 1);
        if (counter == 0) {
            var target_object_ref = transform.parent.gameObject;
            var target_object_anim = target_object_ref.GetComponent<Animation>();
            target_object_anim.Play("goup");
            lt = GetComponent<Light>();
            lt.intensity = 0;
            door.GetComponent<doorController>().buttonsPressed--;
            door.SendMessage("RecieveData");
        }
    }
}
