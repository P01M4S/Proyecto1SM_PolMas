using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour

{
    public BoxCollider2D _boxCollider;
    public AudioClip _audioClip;
    public AudioClip _coinSFX;
    public AudioSource _audioSource;
    public GameManager _gameManager;
  
   void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        _gameManager.AddCoins();

        _boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
        
    }


}