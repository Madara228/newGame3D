using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;
    public GameObject enemyCapsule;
    [SerializeField] GameObject[] gameObjects;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("enemyPos");
        spawn();
        StartCoroutine(creator());
    }

    private IEnumerator creator()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            gameObjects = GameObject.FindGameObjectsWithTag("turel");
            Debug.Log(gameObjects);
            if (gameObjects.Length <= 1)
            {
                Debug.Log("not working");
                spawn();
            }
        }
    }

    void spawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int a = Random.Range(0, 3);
            if (a == 2)
                Instantiate(enemyCapsule, spawnPoints[i].transform.position + new Vector3(0,1,0), transform.rotation);
        }
    }
}
