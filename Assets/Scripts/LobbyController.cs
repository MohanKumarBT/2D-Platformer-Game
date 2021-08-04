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
       
        LevelSelection.SetActive(true);
        buttons.SetActive(false);
    }
 

    public void QuitBtn()
    {
        Application.Quit();
    }
}
