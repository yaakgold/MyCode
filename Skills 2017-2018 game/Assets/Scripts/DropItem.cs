using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    public UnityEngine.GameObject dropObject;
    public int dropAmt = 3;
    public float health = 1f;
    public string id;

	// Use this for initialization
	void Start () {
		
	}
	//x 41.601 y 41.601 z 82.194
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(this.gameObject);
            for (int i = 0; i < dropAmt; i++)
            {
                Instantiate(dropObject, new Vector3(gameObject.transform.position.x,
                                                    gameObject.transform.position.y + 2,
                                                    gameObject.transform.position.z + (int)(i * 1.5)),
                            new Quaternion(dropObject.transform.rotation.x,
                                           dropObject.transform.rotation.y + (int)(i * 1.75),
                                           dropObject.transform.rotation.z,
                                           dropObject.transform.rotation.w),
                            this.transform.parent.parent);
            }
        }
	}
}
