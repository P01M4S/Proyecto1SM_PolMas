using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    public BoxCollider2D _collider;
    public AudioClip _audioClip;
    public AudioSource _audioSource;
     public float deley = 2;
    public float timer = 0;

    public GameManager _gameManager;

    public bool timerEnd = false;

    void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
    }

    void OnTriggerEnter2D (Collider2D collider) 
{
    if(collider.gameObject.CompareTag("Player"))
    {
        _audioSource.Stop();
         _audioSource.Stop();
        timer += Time.deltaTime;
        if(timer >= deley)
        {
            timerEnd = true;
        }
        _audioSource.Play();
    }
}

}
