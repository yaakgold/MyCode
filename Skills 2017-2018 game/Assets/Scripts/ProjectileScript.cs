using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public UnityEngine.GameObject explosion;
    //Damages
    public float stickDamage = .3f;
    public float treeDamage = .2f;
    public float rockDamage = .5f;

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = Wait(0.13f);
    }

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, this.gameObject.transform);

        if (collision.gameObject.GetComponentInParent<DropItem>() != null)
        {
            if (collision.gameObject.GetComponentInParent<DropItem>().id == "Stick")
            {
                collision.gameObject.GetComponentInParent<DropItem>().health -= stickDamage;
            }
            else if (collision.gameObject.GetComponentInParent<DropItem>().id == "Tree")
            {
                collision.gameObject.GetComponentInParent<DropItem>().health -= treeDamage;
            }
            else if (collision.gameObject.GetComponentInParent<DropItem>().id == "Rock")
            {
                collision.gameObject.GetComponentInParent<DropItem>().health -= rockDamage;
            }
        }


        StartCoroutine(coroutine);
        
    }
    private IEnumerator Wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(this.gameObject);
        }
    }
}
