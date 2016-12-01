using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    private GameObject thePlayer;
    private GameObject theGhost;
    private Camera camera;
    private Vector3 teleportPosition;
    private Vector3 playerPosition;
    public RenderTexture Render;

    // Use this for initialization
    void Start () {
        thePlayer = GameObject.Find("PlayerController");
        theGhost = GameObject.Find("theghost");
        camera = GetComponent<Camera>();
    }

  	// Update is called once per frame
  	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
        camera.targetTexture = Render;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);
            teleportPosition = hit.point;
            teleportPosition.y = (teleportPosition.y + 1);
            if (teleportPosition.y != 1 && (hit.collider.gameObject != theGhost)) {
                playerPosition = thePlayer.transform.position;
                playerPosition.y = (playerPosition.y - 1);
                thePlayer.transform.position = teleportPosition;
                theGhost.transform.position = playerPosition;
                theGhost.transform.eulerAngles = new Vector3 ((thePlayer.transform.rotation.x - 90), thePlayer.transform.eulerAngles.y, 0);
            }
        }
    }
}
