using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDoor : MonoBehaviour {

    public float countdown;
    public Text TimeRemaining;
    public GameObject specialkey;
    public GameObject playerone;
    public GameObject teleportation;

    public GameObject rockspawnlocation;

    //public bool keymade;
    
    // Use this for initialization
    void Start () {
        countdown = 12;
	}

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0 && GameObject.FindGameObjectWithTag("SKey") == null)
        {
            GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld = false;
            Instantiate(specialkey, rockspawnlocation.transform.localPosition, rockspawnlocation.transform.localRotation);
            countdown = 15;
            //keymade = false;

        }

        if (countdown < 20)
        {
            TimeRemaining.text = "Remaining Time: " + countdown;
        }
        if (playerone.transform.position == teleportation.transform.position)
        {
         
            TimeRemaining.text = "";
        }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld && countdown > 0)
        {
            GetComponent<Animator>().SetTrigger("DoorOpen");
            Destroy(GetComponent<BoxCollider2D>());
            GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld = false;
        }
    }
}
