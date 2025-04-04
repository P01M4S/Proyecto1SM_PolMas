using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip bgm;
    public AudioClip gameOver;

    public float deley = 2;
    public float timer = 0;

    public GameManager _gameManager;
    public bool _win = false;

    public bool timerEnd = false;

    public void PauseBGM()
    {
        if(_gameManager._isPaused || _win)
        {
            _audioSource.Pause();
        }
        
    }
    public void SoundBGM()
    {
        if(_gameManager.isPlaying)
        {
            _audioSource.Play();
        }
        
    }

void Awake()
{
_audioSource = GetComponent<AudioSource>();
_gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
}

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameManager.isPlaying)
        {
            if(!timerEnd)
            {
             DeathBGM();   
            }

        }
       
    }

    void PlayBGM()
    {
        _audioSource.clip = bgm;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void DeathBGM()
    {   
        _audioSource.Stop();
        timer += Time.deltaTime;
        if(timer >= deley)
        {
            timerEnd = true;
            _audioSource.PlayOneShot(gameOver);
        }
      
    }
}
