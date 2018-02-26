using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour {

    public Text counter;
    public Health h;

    public void Respawner()
    {
        h = FindObjectOfType<Health>();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        counter.text = "3...";
        yield return new WaitForSeconds(1);
        counter.text = "2...";
        yield return new WaitForSeconds(1);
        counter.text = "1...";
        yield return new WaitForSeconds(1);
        h.Death();
    }
}
