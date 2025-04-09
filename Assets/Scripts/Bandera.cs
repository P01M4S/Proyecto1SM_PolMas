using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    public BoxCollider2D _collider;
    public AudioClip _audioClip;
    public AudioSource _audioSource;

    public SoundManager _soundManager;

    public bool timerEnd = false;

    void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
        _collider = GetComponent<BoxCollider2D>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D (Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _soundManager._win = true;
            _soundManager.PauseBGM();
            _audioSource.PlayOneShot(_audioClip);
            SceneManager.LoadScene("MenuPrincipal",LoadSceneMode.Single);
        }
    


}

}
