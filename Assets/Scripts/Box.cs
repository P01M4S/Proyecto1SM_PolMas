using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
public AudioSource _audioSource;
public AudioClip _boxSFX;
public SpriteRenderer _spriteRenderer;
public BoxCollider2D _collider1;
public BoxCollider2D _collider2;

    void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void DestroyBox()
    {
        _audioSource.clip = _boxSFX;
        _audioSource.Play();
        //Destroy(gameObject);
        _spriteRenderer.enabled = false;
        _collider1.enabled = false;
        _collider2.enabled = false;

        Destroy(gameObject, _boxSFX.length);
    }
void OnTriggerEnter2D (Collider2D collider) 
{
    if(collider.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}
}
