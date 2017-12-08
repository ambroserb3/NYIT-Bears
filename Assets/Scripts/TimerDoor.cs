using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDoor : MonoBehaviour {

    public float countdown;
    public Text TimeRemaining;
    public GameObject specialkey;

    public string niceCount;

    public GameObject rockspawnlocation;
    
    // Use this for initialization
    void Start () {
        countdown = 14;
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
            countdown = 14;
        }
        int minutes = Mathf.FloorToInt(countdown / 60F);
        int seconds = Mathf.FloorToInt(countdown - minutes * 60);
        niceCount = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (countdown < 14)
        {
            TimeRemaining.text = "Remaining Time: " + niceCount;
        }

        if (GameObject.Find("playerfiller").GetComponent<Controller>().specialkeyheld == false)
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
