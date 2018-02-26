using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToLookAtPlayer : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("MainPlayer(Clone)").gameObject;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.parent.LookAt(player.transform);
	}
}
