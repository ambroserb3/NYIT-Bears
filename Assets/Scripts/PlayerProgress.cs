using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour {

    public float record;
    public float currTime;
    public string recordTime;


    // Use this for initialization
    void Start () {
        
        //Give the PlayerPrefs some values to send over
       PlayerPrefs.SetFloat("Record Time", 120);
       PlayerPrefs.SetString("Record String", "");
    }

    // Update is called once per frame
    void Update () {
        //PlayerPrefs.SetFloat("Record Time", record);
	}

    void FixedUpdate()
    {
        if (record == 0)
        {
           record = 120;
        }
        //PlayerPrefs.SetFloat("Record Time", record);
    }

}
