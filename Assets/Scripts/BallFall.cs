﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BallFall : MonoBehaviour
{
    public GameObject Ball;
    public Camera camera1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("game over");
        //Debug.Log(Camera.main.transform.position.y);
        if (camera1.transform.position.y-4.9 > Ball.transform.position.y)
        {
            Debug.Log("game over game over game overgame over game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            // Debug.Log(Camera.main.transform.position.y );
            Application.Quit();
        }
    }
}
