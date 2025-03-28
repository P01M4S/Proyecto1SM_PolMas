using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public BoxCollider2D _boxCollider;
    public AudioSource _audioSource;
    public Rigidbody2D _rigidBody;
    public int direction = 1;
    public float speed = 2;
  
   void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate() 
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Pared") || collision.gameObject.layer == 6)
        {
            direction *= -1;
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Desaparece();
        }
        
    }
    public void Desaparece()
    {
        direction = 0;
        
        _boxCollider.enabled = false;
        Destroy(gameObject, 0);
        
    }

}