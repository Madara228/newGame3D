using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurelScriptNew : MonoBehaviour {

    public GameObject[] fireGobs;
    GameObject player;

	void Start () {
        StartCoroutine(findAndDoAnythink());	
	}
    private IEnumerator findAndDoAnythink()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            fireGobs = GameObject.FindGameObjectsWithTag("turel");
            player = GameObject.FindGameObjectWithTag("Player");
            for (int i = 0; i < fireGobs.Length; i++)
            {
                fireGobs[i].transform.LookAt(player.transform.position);
                TurelScript turelScript = fireGobs[i].GetComponent<TurelScript>();
                if (fireGobs[i].active)
                {
                    turelScript.fire();
                }
            }
            Debug.Log("worked");
        }
    }
}