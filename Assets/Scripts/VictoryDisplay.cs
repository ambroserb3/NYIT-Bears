using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDisplay : MonoBehaviour {

    public Text recordDisplay;
    public Text yourtime;

    private PlayerProgress playerProgress;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //playerProgress.recordTime = PlayerPrefs.GetString("Record Time");

        recordDisplay.text = "Record Time: " + GameObject.Find("Controller").GetComponent<DataController>().goodTime;
        
        yourtime.text = "Your Time was: " + GameObject.Find("Teleporter T").GetComponent<WinTeleport>().victorytime;

    }
}
