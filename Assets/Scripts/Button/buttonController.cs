using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
    private Light light;
    private AudioSource audioSource;
    private DoorController doorController;
    private Animation animation;
    private int counter;
    public GameObject door; //where is this set?

  // Use this for initialization
  void Start () {
    counter = 0;
    light = GetComponent<Light>();
    audioSource = GetComponent<AudioSource>();
    doorController = door.GetComponent<doorController>();
    animation = transform.parent.gameObject.GetComponent<Animation>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (counter == 0) {
        animation.Play("godown");
        light.intensity = 2;
        audioSource.Play();
        doorController.buttonsPressed++;
        door.SendMessage("RecieveData");
    }
    counter++;
  }

  void OnTriggerExit(Collider other)
  {
      counter--;//Before the if?
      if (counter == 0) {
          animation.Play("goup");
          light.intensity = 0;
          doorController.buttonsPressed--;
          door.SendMessage("RecieveData");
      }
  }
}
