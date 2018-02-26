using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    [Range(0, 1)]
    public float lessenHealthAmt;
    
    // Use this for initialization
    void Start()
    {

    }
    
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<Health>().isDead)
            {
                collision.gameObject.GetComponent<Health>().ReduceHealth(lessenHealthAmt);
            }
        }
    }
}
