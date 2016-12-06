using UnityEngine;
using System.Collections;

public class doorController : MonoBehaviour {

    public int buttonsPressed;
    public int numberOfButtons;
    private AudioSource audioclip;
    private bool isDoorUp;

    // Use this for initialization
    void Start () {
        buttonsPressed = 0;
	}

    void RecieveData()
    {
        if (buttonsPressed == numberOfButtons) {
            GetComponent<Animation>().Play("goup1");
            GetComponent<Animation>().Play("goup");
            audioclip = GetComponent<AudioSource>();
            audioclip.Play();
            isDoorUp = true;
        }
        if (buttonsPressed != numberOfButtons && isDoorUp == true)
        {
            GetComponent<Animation>().Play("godown1");
            GetComponent<Animation>().Play("godown");
            isDoorUp = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Buttons Pressed: " + buttonsPressed + " | Door Up: " + isDoorUp);
    }
}
