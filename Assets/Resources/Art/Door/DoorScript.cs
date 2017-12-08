using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && GameObject.Find("playerfiller").GetComponent<Controller>().keyheld)
        {
                GetComponent<Animator>().SetTrigger("DoorOpen");
                Destroy(GetComponent<BoxCollider2D>());
                GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld = false;
        }
    }
}
