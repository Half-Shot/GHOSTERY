using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private GameObject theplayer;
    private GameObject theghost;
    private Vector3 teleportPosition;
    private Vector3 playerPosition;
    private ParticleSystem particleSys;
    private AudioSource audioclip;
    private Light lt;
    public RenderTexture Redner;

    // Use this for initialization
    void Start () {
        theplayer = GameObject.Find("PlayerController");
        theghost = GameObject.Find("theghost");
        particleSys = GetComponent<ParticleSystem>();
        audioclip = GetComponent<AudioSource>();
        lt = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        lt.intensity = (lt.intensity - 1);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
        GetComponent<Camera>().targetTexture = Redner;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);
            //Debug.Log("Player clicked: " + hit.point);
            theplayer = (GameObject.Find("PlayerController"));
            teleportPosition = hit.point;
            teleportPosition.y = (teleportPosition.y + 1);
            if (teleportPosition.y != 1 && (hit.collider.gameObject.name != "theghost")) {
                playerPosition = theplayer.transform.position;
                playerPosition.y = (playerPosition.y - 1);
                theplayer.transform.position = teleportPosition;
                theghost.transform.position = playerPosition;
                theghost.transform.eulerAngles = new Vector3 ((theplayer.transform.rotation.x - 90), theplayer.transform.eulerAngles.y, 0);
                particleSys.Play();
                audioclip.Play();
                lt.intensity = 8;
            }
        }
    }
}
