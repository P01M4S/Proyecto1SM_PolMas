using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

public bool isPlaying = true;
public bool _isPaused = false;
public SoundManager _soundManager;
public GameObject pause;
public int Coins = 0;
public Text coinsText;

void Awake()
{
_soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
}
void Start()
{
    coinsText.text = "Coins: " + Coins.ToString();
}

void Update()
{
    if(Input.GetButtonDown("Pause"))
    {
        if(_isPaused)
        {
            Time.timeScale = 1;
            _isPaused = false;
            _soundManager.PauseBGM();
            pause.SetActive(false);
        }
        else
        {
        Time.timeScale = 0;
        _isPaused = true;
        _soundManager.PauseBGM();
        pause.SetActive(true);
        }
    }
}
public void MainMenu()
{
    SceneManager.LoadScene(1);
    Time.timeScale = 1;
}

public void AddCoins()
{
    Coins++;
    coinsText.text = "Coins: " + Coins.ToString();
}

}
