using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartBtn(string scene)
    {
        SceneManager.LoadScene(scene); 
    }
    public void Lobbybtn()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
