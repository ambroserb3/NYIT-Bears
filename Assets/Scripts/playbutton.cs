using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(GameObject.Find("playerfiller"));
        Destroy(GameObject.Find("Teleporter T"));

    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("main");
    }
}
