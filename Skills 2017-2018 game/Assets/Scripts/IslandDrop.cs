using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandDrop : MonoBehaviour {

    private GameObject theIsland;
    
    // Use this for initialization
    void Start ()
    {
        theIsland = GameObject.FindGameObjectWithTag("Island");
    }

    public bool gameStarted = false;

    public float islandDropAmt = .005f;
    public Animator dropAnim;

    public Text timer;

    float timeTillDropCounter = 0.0f;
    public int EarthquakeIntervals = 30;

    float inGameTime = 0.0f;
    //This represents ten minutes
    public float totalStageOneTime = 600f;

    public float stageOneTimeLeft = 600f;

	// Update is called once per frame
	void Update ()
    {
        if(gameStarted)
        {
            UpdateTimer();
            inGameTime += Time.deltaTime;
            stageOneTimeLeft -= Time.deltaTime;
            timeTillDropCounter += Time.deltaTime;
            if ((int)timeTillDropCounter % EarthquakeIntervals == 1)
            {
                dropAnim.SetBool("Earthquake", true);
                theIsland.transform.position = new Vector3(theIsland.transform.position.x,
                                                       theIsland.transform.position.y - islandDropAmt,
                                                       theIsland.transform.position.z);


            }
            else
            {
                dropAnim.SetBool("Earthquake", false);
            }
        }
        /*
         if(time reaches 5 mins){
         changes camera to the last cinematic, main player object is destroy,
         camera zooms out, volcano explodes, game over
         }          
         */
    }

    private void UpdateTimer()
    {
        int min = Mathf.FloorToInt(stageOneTimeLeft / 60f);
        int sec = Mathf.RoundToInt(stageOneTimeLeft % 60f);

        if(sec == 60)
        {
            sec = 0;
            min++;
        }

        timer.text = "TOTAL TIME: " + min.ToString("00") + ":" + sec.ToString("00");
    }
}
