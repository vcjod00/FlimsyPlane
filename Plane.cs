using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    Rigidbody body;
    public GameObject gameOverMenu;
    static public bool gameOver;
    

    // Starts game
    void Start()
    {
        Time.timeScale = 1.75f;
        body = gameObject.GetComponent<Rigidbody>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
       //sets the game over option when plane crashes
       if (gameOver)
        {
           gameOverMenu.SetActive(true);
        }
       //levitates the plane upwards when clicking mouse
        if(Input.GetMouseButton(0))
        {
            body.AddForce(new Vector3(0, 50, 0), ForceMode.Acceleration);
        }
    }

    //when plane crashess
    public void OnTriggerEnter(Collider collider)
    {
        //plane stops and game over menu displayed
        gameOver = true;
        body.isKinematic = true;
    }
}
