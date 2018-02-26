using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public UnityEngine.GameObject objects;
    public bool runOnstart = true;
	// Use this for initialization
	void Start () {
        if(runOnstart)
        {
            Spawn();
        }
	}

    //This is used to spawn the object
    public void Spawn()
    {
        Instantiate(objects, this.transform.position, this.transform.rotation);
    }
}
