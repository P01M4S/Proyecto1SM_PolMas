using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public float jumpForce = 7;

    public int direction = 1;

    private float inputHorizontal;

    private Rigidbody2D rigidBody2D;

    public GroundSensor groundSensor;

    void Awake() 
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        groundSensor = GetComponentInChildren<GroundSensor>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Teleport Personaje
        // transform.position = new Vector3(-70.2374f, -2.948f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
if(Input.GetButtonDown("Jump") && groundSensor.isGrounded == true)
{
rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
}
      //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);  
      //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
      //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
       rigidBody2D.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody2D.velocity.y); 
       //rigidBody2D.addforce(new Vector2(inputHorizontal, 0))
       //rigidBody2D.MovePosition(new Vector2(100, 0))
    }
}
