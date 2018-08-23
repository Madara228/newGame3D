using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TurelScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    private float fireTime = 1.5f;
    GameObject player;
    newPlayerScript newPlayerScript = new newPlayerScript();
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FindAndFire());
    }
    private IEnumerator FindAndFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireTime);
            transform.LookAt(player.transform.position);
            GameObject Temporary_Bullet;
            Temporary_Bullet = Instantiate(bullet, firePos.position, firePos.transform.rotation) as GameObject;
            //Temporary_Bullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigid = Temporary_Bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward * 1500f);
            Destroy(Temporary_Bullet, 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            newPlayerScript newPlayerScript = player.GetComponent<newPlayerScript>();
            newPlayerScript.playerPoints++;
            Debug.Log(newPlayerScript.playerPoints + "pp");
            this.gameObject.SetActive(false);
        }
    }
}
