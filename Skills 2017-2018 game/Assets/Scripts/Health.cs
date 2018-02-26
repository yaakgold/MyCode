using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float health;
    public Scrollbar healthBar;
    public ObjectSpawn spawner;
    public bool isDead = false;
    public PlayerRespawn counter;
    public GameObject deathScreen;
    public GameObject inventoryUI;
    

    void Start()
    {
        healthBar = FindObjectOfType<Scrollbar>();
        spawner = GameObject.FindGameObjectWithTag("Player Spawn").GetComponent<ObjectSpawn>();
        deathScreen = GameObject.Find("Death Parent").transform.GetChild(0).gameObject;
        inventoryUI = GameObject.Find("Inventory").transform.gameObject;
        counter = FindObjectOfType<PlayerRespawn>();
        deathScreen.SetActive(false);
        isDead = false;
        health = 1f;
    }
    
    public void ReduceHealth(float amt)
    {
        if (health - amt <= 0)
        { 
            isDead = true;
            deathScreen.SetActive(true);
            inventoryUI.SetActive(false);
            counter.Respawner();
        }
        else
        {
            health -= amt;
        }
    }

    public void Update()
    {
        healthBar.size = health;
    }

    public void Death()
    {
        //TODO: DO the rest of the stuff for the death, animation, and show title 
        spawner.Spawn();
        inventoryUI.SetActive(true);
        Destroy(this.gameObject);
    }
}
