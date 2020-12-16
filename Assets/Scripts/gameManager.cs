using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    
    public static gameManager instance;

    public GameObject player;
    public GameObject startButton;
    public GameObject title;
    public GameObject tap_to_play;
    public GameObject jetPack;
    public GameObject restartPanel;
    public GameObject scorePanel;


    public bool start;
    public bool active;
    public bool gameOver;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        active = false;
        start = false;
        gameOver = false;
        Invoke("activateGame", 1f);
    }

    public void activateGame()
    {
        active = true;
        startButton.SetActive(true);
    }

    public void startGame()
    {
        /*
         * Animations here
         * 
         */
        scorePanel.SetActive(true);
        startButton.SetActive(false);
        start = true;
        clickExplode();
        title.GetComponent<Animator>().Play("title_up");
        tap_to_play.GetComponent<Animator>().Play("tap_pop_down");
    }

    public void endGame()
    {
        restartPanel.SetActive(true);
        scoreManager.instance.endGame();
        Invoke("gameOverTrue", 1f);
    }

    void gameOverTrue() {
        gameOver = true;
    }

    void clickExplode()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //var instance = Instantiate(explosion, touchPos, Quaternion.identity);
        //var effector = instance.GetComponent<PointEffector2D>();
        //Destroy(effector, 0.1f);
        //Destroy(instance, 0.4f);

        soundManager.instance.explode();

        var instance = Instantiate(explosion, touchPos, Quaternion.identity);
        Destroy(instance, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (start && Input.GetMouseButtonDown(0))
        {
            clickExplode();
            jetPack.SetActive(true);
            Invoke("jetPackOff",0.2f);
        }

        if(gameOver && Input.anyKeyDown)
        {
            Debug.Log("game over game over game overgame over game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void jetPackOff()
    {
        jetPack.SetActive(false);
    }
}
