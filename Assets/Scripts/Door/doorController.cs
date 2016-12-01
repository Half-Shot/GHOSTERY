using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public int numberOfButtons;
    private int buttonsPressed;
    private AudioSource audioSource;
    private Animation animation;
    private bool isDoorUp;

    // Use this for initialization
    void Start () {
        buttonsPressed = 0;
        animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    void RecieveData()
    {
        if (buttonsPressed == numberOfButtons) {
            animation.Play("goup");
            audioSource.Play();
            isDoorUp = true;
        }
        else if (isDoorUp)
        {
            animation.Play("godown");
            isDoorUp = false;
        }
    }
}
