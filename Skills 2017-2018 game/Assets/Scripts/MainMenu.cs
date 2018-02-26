using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public ObjectSpawn playerSpawn;
    public GameObject cam;
    public GameObject nonMMObject;
    public GameObject nonCredOrHs;
    public GameObject credOrHs;
    public GameObject credits;
    public GameObject highScores;
    public HighScore scores;

    public IslandDrop idScript;

	// Use this for initialization
	void Start ()
    {
        playerSpawn = (ObjectSpawn)GameObject.FindGameObjectWithTag("Player Spawn").GetComponent("ObjectSpawn");
        cam = GameObject.FindGameObjectWithTag("mmCam");
        idScript = (IslandDrop)GameObject.FindGameObjectWithTag("EGO Island").GetComponent("IslandDrop");

        nonMMObject = GameObject.FindGameObjectWithTag("Non Main Menu UI");
        nonMMObject.SetActive(false);

        nonCredOrHs = GameObject.Find("NonCredOrHs");
        credOrHs = GameObject.Find("CredOrHs");
        credits = GameObject.Find("Credits");
        highScores = GameObject.Find("High Scores");

        credOrHs.SetActive(false);
    }

    public void PlayGame()
    {
        //Play Game setup
        cam.SetActive(false);
        playerSpawn.Spawn();
        nonMMObject.SetActive(true);
        idScript.gameStarted = true;
        this.gameObject.SetActive(false);
    }

    public void Credits()
    {
        nonCredOrHs.SetActive(false);
        credOrHs.SetActive(true);
        credits.SetActive(true);
        highScores.SetActive(false);
    }

    public void HighScores()
    {
        nonCredOrHs.SetActive(false);
        credOrHs.SetActive(true);
        highScores.SetActive(true);
        credits.SetActive(false);
    }

    public void ReturnToMenu()
    {
        nonCredOrHs.SetActive(true);
        credOrHs.SetActive(false);
        highScores.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
