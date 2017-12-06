using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour {

    public GameObject rocks;
    public float timer;
    public GameObject button;
    public GameObject rockspawnlocation;
    Vector3 destination;

	// Use this for initialization
	void Start () {
        timer = 1.5F;
	}
	
	// Update is called once per frame
	void Update () {

        if (button.GetComponent<ButtonScr>().barrierdown)  //will check if true
        {
            timer -= Time.deltaTime;
        }

        destination = rockspawnlocation.transform.position;

        if (timer < 0)
        {
            Instantiate(rocks, rockspawnlocation.transform.localPosition, rockspawnlocation.transform.localRotation);
            timer = 5;
        }
    }


}
