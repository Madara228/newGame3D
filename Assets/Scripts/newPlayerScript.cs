using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newPlayerScript : MonoBehaviour {


    #region public vars
    public float speed = 5f;
    public float rotateSpeed = 50f;
    public GameObject bullet;
    public Transform firePos;
    public Text healthText;
    public GameObject panel;
    public int playerPoints = 0;
    //public GameObject head;
    public GameObject camera;
    #endregion
    #region private vars
    [SerializeField] Rigidbody rb;
    private Vector3 movement;
    float jumpspeed = 250f;
    bool isGround;
    private int playerHealth = 5;

    float yaw = 0.0f;
    float yawY = 0.0f;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        changeHealthText();
        Cursor.visible = false;
    }
	
	void Update () {
        movement.z = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        yaw += Input.GetAxis("Mouse X") * rotateSpeed*Time.fixedDeltaTime;
        yawY -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        yawY = Mathf.Clamp(yawY, -10, 10);
        Debug.Log(yawY);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Temporary_Bullet;
            Temporary_Bullet = Instantiate(bullet, firePos.position, camera.transform.rotation) as GameObject;
            //Temporary_Bullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigid = Temporary_Bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward *1500f);
            Destroy(Temporary_Bullet, 3f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
         //   Debug.Log("work");
            rb.velocity = Vector3.up * jumpspeed * Time.fixedDeltaTime;
            isGround = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyBullet")
        {
           playerHealth -= 1;
           changeHealthText();
            Destroy(collision.gameObject);
           if (playerHealth <= 0)
           {
                Cursor.visible = true;
                youLose();
           }
        }
       
    }
    private void FixedUpdate()
    {
        transform.Translate(movement, Space.Self);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
    void changeHealthText()
    {
        healthText.text = playerHealth.ToString();
    }

    void youLose()
    {
        panel.SetActive(true);
        GameObject scoreText = GameObject.Find("ScoreText");
        Text txt = scoreText.GetComponent<Text>();
        txt.text = "Результат :" + playerPoints.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "healer")
        {
            playerHealth += 1;
            Destroy(other.gameObject);
            changeHealthText();
        }
    }
}
