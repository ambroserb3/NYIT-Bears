using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public GameObject key;
    private Vector3 offset;
    public bool first;


    // Use this for initialization
    void Start() {
        offset = new Vector3(0.5F,2,0);
    }
    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Button").GetComponent<ButtonScr>().barrierdown && first == false)  //will check if true
        {
            key.transform.position = (key.transform.position - offset);
            first = true;
        }
        else if (!GameObject.Find("Button").GetComponent<ButtonScr>().barrierdown) //will check if false
        {

        }

    }
}
