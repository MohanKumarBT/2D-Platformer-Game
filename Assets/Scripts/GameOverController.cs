using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartBtn(string scene)
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(scene);
        //SoundManager.Instance.Play(Sounds.LevelEntry);
        Time.timeScale = 1;
    }
    public void Lobbybtn()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene("LobbyScene");
    }
    public void QuitBtn()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
