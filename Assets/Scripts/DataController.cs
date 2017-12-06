using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files

public class DataController : MonoBehaviour
{
    private PlayerProgress playerProgress;
    public AudioSource mainmusic;
    public GameObject controller;
    public string goodTime;

    public string currentTime;

    void Start()
    {
        DontDestroyOnLoad(controller);
        playerProgress = controller.GetComponent<PlayerProgress>();

        LoadPlayerProgress();
        DontDestroyOnLoad(mainmusic);

        SceneManager.LoadScene("title");
    }

    public void Update()
    {
        int minutes = Mathf.FloorToInt(playerProgress.record / 60F);
        int seconds = Mathf.FloorToInt(playerProgress.record - minutes * 60);
        goodTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        int min = Mathf.FloorToInt(playerProgress.currTime / 60F);
        int sec = Mathf.FloorToInt(playerProgress.currTime - minutes * 60);
        currentTime = string.Format("{0:0}:{1:00}", min, sec);

    }

    public void SubmitNewPlayerScore(float newRecord)
    {
        // If newScore is greater than playerProgress.highestScore, update playerProgress with the new value and call SavePlayerProgress()
        if (newRecord < playerProgress.record)
        {
            playerProgress.record = newRecord;
            SavePlayerProgress();
        }
    }

    public void SubmitCurrentPlayerScore(float rrecord)
    {
            playerProgress.currTime = rrecord;
    }

    public float GetHighestPlayerScore()
    {
        return playerProgress.record;
    }

    // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
    private void LoadPlayerProgress()
    {

        // If PlayerPrefs contains a key called "highestScore", set the value of playerProgress.highestScore using the value associated with that key
        if (PlayerPrefs.HasKey("Record Time"))
        {
            playerProgress.record = PlayerPrefs.GetFloat("Record Time");
        }
    }

    // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
    private void SavePlayerProgress()
    {
        // Save the value playerProgress.highestScore to PlayerPrefs, with a key of "highestScore"
        PlayerPrefs.SetFloat("Record Time", playerProgress.record);
        PlayerPrefs.SetString("Record Time", playerProgress.recordTime);

    }
}