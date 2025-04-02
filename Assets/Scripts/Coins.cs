using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour

{
    public BoxCollider2D _boxCollider;
    public AudioClip _audioClip;
    public AudioClip _coinSFX;
    public AudioSource _audioSource;
  
   void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Desaparece();
            _audioSource.clip = _coinSFX;
            _audioSource.Play();
        }
        
    }
    public void Desaparece()
    {

        _boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
        
    }

}