using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
public void MainMenu()
{
    SceneManager.LoadScene(1);
}

    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
