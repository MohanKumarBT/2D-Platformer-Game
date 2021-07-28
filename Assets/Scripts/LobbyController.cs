using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
