using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsroll : MonoBehaviour {

    public float timer;


    // Use this for initialization
    void Start () {
        timer = 0;
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        if (timer > 6) {
            SceneManager.LoadScene("title");
        }
    }
}
