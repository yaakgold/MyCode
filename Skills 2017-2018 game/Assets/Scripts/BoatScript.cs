using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatScript : Interactable
{

    public int logs = 14, leaves = 10, sticks = 20;
    private int playerLogs, playerLeaves, playerSticks;
    private int logsRemoved, leavesRemoved, sticksRemoved;
    private string[] arrStrings;
    new string name;

    public GameObject canvas;
    public Text infoText;
    public float liftAmt;
    public Animator endGameAnim;

    public GameObject VirtualBoatObject, RealBoatObject;
    public bool whateverIWant, StickCompletion, LogCompletion, LeavesCompletion;
    // Use this for initialization
    void Start()
    {
        whateverIWant = false;
        StickCompletion = false;
        LogCompletion = false;
        LeavesCompletion = false;
        arrStrings = new string[4];
        arrStrings[0] = "ShowView01";
        arrStrings[1] = "ShowView02";
        arrStrings[2] = "ShowView03";
        arrStrings[3] = "ShowView04";
        //canvas = GameObject.Find("Canvas_FloatText").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject canvasSpawned;
    private bool spawnedOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Quaternion getRotation = new Quaternion();
            getRotation.SetFromToRotation(GameObject.Find("MainPlayer(Clone)").gameObject.transform.position,
                                      GameObject.Find("MainPlayer(Clone)").gameObject.transform.position);

            whateverIWant = true;
            if(!spawnedOnce)
            {
                spawnedOnce = true;
                canvasSpawned = Instantiate(canvas, gameObject.transform.position, getRotation) as GameObject;
                infoText = canvasSpawned.GetComponentInChildren<Text>();
                UpdateText();
            }
        }

    }

    public void UpdateText()
    {
        infoText.text = "LOGS   STICKS   LEAVES" + "\n" + 
                        playerLogs + "/" + logs + "    " + playerSticks + "/" + sticks +
                        "     " + playerLeaves + "/" + leaves + "\n\n\n\n";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            whateverIWant = false;
            Destroy(canvasSpawned);
            spawnedOnce = false;
        }

    }

    public override void Interact()
    {
        base.Interact();
        CheckMaterials();
    }

    private void CheckMaterials()
    {
        if (whateverIWant)
        {
            //checks for all resources in each inventory slot
            for (int x = 0; x < FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots.Length; x++)
            {
                name = FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].icon.sprite.name;
                
                if (name == "Stick")
                {
                    if(!StickCompletion)
                    {

                        for (int i = 0; i < FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].currentSlotCount; i++)
                        {
                            if(playerSticks < sticks)
                            {
                                playerSticks++;
                                sticksRemoved++;
                            }
                        }
                        FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].RemoveItem(sticksRemoved);
                        sticksRemoved = 0;
                    }
                    if (playerSticks >= sticks)
                    {
                        StickCompletion = true;
                    }
                }
                if (name == "Log")
                {
                    if(!LogCompletion)
                    {
                        for (int i = 0; i < FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].currentSlotCount; i++)
                        {
                            if(playerLogs < logs)
                            {
                                playerLogs++;
                                logsRemoved++;
                            }
                        }
                        //playerLogs += FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].currentSlotCount;
                        FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].RemoveItem(logsRemoved);
                        logsRemoved = 0;
                    }
                    if (playerLogs >= logs)
                    {
                        LogCompletion = true;
                    }
                }
                if (name == "Leaf")
                {
                    if(!LeavesCompletion)
                    {
                        for(int i = 0; i < FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].currentSlotCount; i++)
                        {
                            if(playerLeaves < leaves)
                            {
                                playerLeaves++;
                                leavesRemoved++;
                            }
                        }
                        //playerLeaves += FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].currentSlotCount;
                        FindObjectOfType<InventoryUI>().GetComponent<InventoryUI>().slots[x].RemoveItem(leavesRemoved);
                        leavesRemoved = 0;
                    }
                    if (playerLeaves >= leaves)
                    {
                        LeavesCompletion = true;
                    }
                }
                if (StickCompletion && LogCompletion && LeavesCompletion)
                {
                    //destroy virtual boat, create real boat
                    Transform coor = VirtualBoatObject.transform;
                    Destroy(VirtualBoatObject);
                    Instantiate(RealBoatObject, coor.position, coor.rotation);

                    //select a random end game scene
                    int num = (int)Random.Range(1, 5);
                    endGameAnim.SetBool(arrStrings[num], true);

                    return;
                }
                UpdateText();
            }
        }
    }
}
