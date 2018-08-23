using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] turels;
    float spawnSpeed = 4f;

    
    
    private void Start()
    {
        StartCoroutine(SpawnerEnemy()); 
    }

    private IEnumerator SpawnerEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            int a = Random.Range(0, 3);
            if (turels[a] != null)
            {
                turels[a].SetActive(true);
            }
        }
    }
}
