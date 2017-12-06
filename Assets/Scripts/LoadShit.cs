using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShit : MonoBehaviour {

    public AudioSource mainmusic;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(mainmusic);
        Debug.Log("yo");
    }

    private void FixedUpdate()
    {
        SceneManager.LoadScene("title");
    }
}
