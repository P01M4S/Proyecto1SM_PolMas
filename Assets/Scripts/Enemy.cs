using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction = 1;
    public float speed = 2.5f;
    public Animator _animator;
    public AudioSource _audioSource;
    public Rigidbody2D _rigidBody;
    public AudioClip _deadSFX;
    public BoxCollider2D _boxCollider;
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

void Start()
    {
speed = 0;
    }

    
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }
void OnBecameVisible()
    {
        speed = 2.5f;
    }

     void OnBecameInvisible()
    {
        speed = 0;
    }

    public void Death()
    {
        direction = 0;
        
        _animator.SetTrigger("Dead");
        _boxCollider.enabled = false;
        Destroy(gameObject, 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Pared") || collision.gameObject.layer == 6)
        {
            direction *= -1;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            PlayerControler playerScript = collision.gameObject.GetComponent<PlayerControler>();
            playerScript.Death();
        }
    }
}
