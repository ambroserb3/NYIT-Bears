using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		if (Input.GetKeyDown(KeyCode.A)){
			GetComponent<Animator>().SetTrigger("DoorOpen");
			Destroy(GetComponent<BoxCollider2D>());
		}	
	}
}
