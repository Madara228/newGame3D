using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerScript : MonoBehaviour {


    #region public vars
    public float speed = 10f;
    public float rotateSpeed = 90f;
    public GameObject bullet;
    public Transform firePos;
    #endregion
    #region private vars
    [SerializeField] Rigidbody rb;
    private Vector3 movement;
    private float rotation;
    float jumpspeed = 300f;
    bool isGround;
    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        Debug.Log(isGround);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject Temporary_Bullet;
            Temporary_Bullet = Instantiate(bullet, firePos.position,firePos.transform.rotation) as GameObject;
            Temporary_Bullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigid = Temporary_Bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward *1000f);
            Destroy(Temporary_Bullet, 5f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }
    private void FixedUpdate()
    {
        transform.Translate(movement, Space.Self);
        transform.Rotate(transform.rotation.x,rotation,transform.rotation.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            Debug.Log("work");
            rb.velocity = Vector3.up * jumpspeed * Time.deltaTime;
            isGround = false;
        }
    }
}
