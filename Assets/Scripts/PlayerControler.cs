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

    private SpriteRenderer _spriteRenderer;

    public Animator _animator;

    public AudioSource _audio;
    public AudioClip jumpSXF;
    public AudioClip deathSFX;

    public BoxCollider2D _boxCollider;
    public GameManager _gameManager;

    public SoundManager _soundManager;

    void Awake() 
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _soundManager = GameObject.Find("BGM Manager").GetComponent<SoundManager>();
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
        if(!_gameManager.isPlaying)
        {
return;
        }
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && groundSensor.isGrounded == true)
        {
        Jump();
        }

        Movement();

        _animator.SetBool("IsJump", !groundSensor.isGrounded);

        /*if(groundSensor.isGrounded)
        {
            _animator.SetBool("IsJump", false);
        }
        else
        {
            _animator.SetBool("IsJump", true);
        }*/

      //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);  
      //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
      //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
       rigidBody2D.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody2D.velocity.y); 
       //rigidBody2D.addforce(new Vector2(inputHorizontal, 0))
       //rigidBody2D.MovePosition(new Vector2(100, 0))
    }

    void Movement()
    {
        if(inputHorizontal > 0)
        {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _animator.SetBool("IsRun", true);
        }
        else if(inputHorizontal < 0)
        {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        _animator.SetBool("IsRun", true);
        }

        else if (inputHorizontal == 0)
        {
            _animator.SetBool("IsRun", false);
        }
    }

    void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        _animator.SetBool("IsJump", true);

        _audio.PlayOneShot(jumpSXF);
    }

    public void Death()
    {
_animator.SetTrigger("IsDead");

_audio.PlayOneShot(deathSFX);
_boxCollider.enabled = false;
Destroy(groundSensor.gameObject);

rigidBody2D.AddForce(Vector2.up * jumpForce / 4, ForceMode2D.Impulse);

inputHorizontal = 0;
rigidBody2D.velocity = Vector2.zero;
_soundManager.Invoke("DeathBGM", 4);
_gameManager.isPlaying = false;

Destroy(gameObject, 5);
    }
}
