using UnityEngine;
using System.Collections;

public class onClickLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("AAA");
        }
    }

    void OnMouseDown()
    {
        Application.LoadLevel("test1");
    }
}
