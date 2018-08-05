using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private Rigidbody rb;
    public Vector3 offset;
    float limit = 80f;
    float rotate = 0.5f;
    public Camera _camera;
    private float X, Y;
    void Start(){
        //camera rotate_start
        offset = new Vector3(0f, 1f, -3f);
        _camera.transform.position = transform.position + offset;
        rb = GetComponent<Rigidbody>();
        _camera.transform.position = (_camera.transform.localRotation * offset + transform.position);
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal")*1.5f;
        float z = Input.GetAxis("Vertical") * 1.5f;
        #region cam rotation
        if (x != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan(x) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        if (x > 0)
        {
            X = _camera.transform.localEulerAngles.y + rotate;
          //Y = Mathf.Clamp (Y, -limit, limit);
            _camera.transform.localEulerAngles = new Vector3(21f, X, 0);
            _camera.transform.position = (_camera.transform.localRotation * offset + transform.position);
        }
        else if (x < 0)
        {
            X = _camera.transform.localEulerAngles.y - rotate;
            //Y = Mathf.Clamp(Y, -limit, limit);
            _camera.transform.localEulerAngles = new Vector3(21f, X, 0);
            _camera.transform.position = (_camera.transform.localRotation * offset + transform.position);
        }
        else
        {
            _camera.transform.position = (_camera.transform.localRotation * offset + transform.position);
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(transform.position.x, 200f, transform.position.z));
        }
    }
}
