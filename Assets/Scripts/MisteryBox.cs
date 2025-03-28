using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    public Animator _animator;
    public AudioSource _audioSource;
    public AudioClip _misteryBoxSFX;
    public bool _isOpen = false;
    public AudioClip _openSFX;
    private SpriteRenderer _spriteRender;
    public Transform _vida;
    public GameObject vidaPrefab;
    

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    void ActivateBox()
    {
        if(!_isOpen)
        {
            _spriteRender.enabled = true;
            _animator.SetTrigger("Open");
            _audioSource.clip = _misteryBoxSFX;
            Instantiate(vidaPrefab, _vida.position, _vida.rotation);
            _isOpen = true;
        }
        else
        {
            _audioSource.clip = _openSFX;
        }
        
        _audioSource.Play();
    }


   void OnTriggerEnter2D(Collider2D collider)
   {
        if(collider.gameObject.CompareTag("Player"))
        {
            ActivateBox();
        }
   }
}
