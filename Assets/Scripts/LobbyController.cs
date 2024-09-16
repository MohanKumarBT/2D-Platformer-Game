using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject LevelSelection;
    public GameObject buttons;
    public void PlayBtn()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
        buttons.SetActive(false);
       
    }
 

    public void QuitBtn()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
