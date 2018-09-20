using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TurelScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    GameObject player;
    GameObject healer;
     private void OnEnable()
    {
        //gameControllerObject = GameObject.Find("GameController");
       // GameControllerScript gameControllerScript = gameControllerObject.GetComponent<GameControllerScript>();
        player = GameObject.FindGameObjectWithTag("Player");
        healer = Resources.Load("Cylinder") as GameObject;
    }


    public void fire()
    {
        GameObject Temporary_Bullet;
        Temporary_Bullet = Instantiate(bullet, firePos.position, firePos.transform.rotation) as GameObject;
        //Temporary_Bullet.transform.Rotate(Vector3.left * 90);
        Rigidbody rigid = Temporary_Bullet.GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * 1500f);
        Destroy(Temporary_Bullet, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            newPlayerScript newPlayerScript = player.GetComponent<newPlayerScript>();
            newPlayerScript.playerPoints++;
            Debug.Log(newPlayerScript.playerPoints + "pp");
            this.gameObject.SetActive(false);
            int a = Random.Range(0,2);
            if(a == 0)
            {
                Instantiate(healer, transform.position, Quaternion.identity);

            }
        }
        else if(collision.gameObject.tag == "healer")
        {
            Destroy(this.gameObject);
        }
    }
}
