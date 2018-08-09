using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turelScript : MonoBehaviour {
    public GameObject bullet;
    public Transform firePos;

    private void Start()
    {
        StartCoroutine(findAndFire());
    }
    private IEnumerator findAndFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform.position);
            GameObject Temporary_Bullet;
            Temporary_Bullet = Instantiate(bullet, firePos.position, firePos.transform.rotation) as GameObject;
            Debug.Log("Instnce");
            Debug.Log(player.transform.position);
            Temporary_Bullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigid = Temporary_Bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward * 1500f);
            Destroy(Temporary_Bullet, 3f);
        }
    }
}
