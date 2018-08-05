using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerScript : MonoBehaviour {


    #region public vars
    public float speed = 10f;
    public float rotateSpeed = 90f;
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
    }
    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }
    private void FixedUpdate()
    {
        transform.Translate(movement, Space.Self);
        transform.Rotate(0f,rotation,0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            Debug.Log("work");
            rb.velocity = Vector3.up * jumpspeed * Time.deltaTime;
            isGround = false;
        }
        

    }
}
