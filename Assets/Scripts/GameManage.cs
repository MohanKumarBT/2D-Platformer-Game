using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [SerializeField] private GameObject[] Hearts;
    [SerializeField] private GameObject HeartCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] public GameObject player;

    private void Awake()
    {
        HeartCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].SetActive(true);
        }
    }
    public void Heart(int health)
    {
        if (health > 3)
        {
            health = 3;
        }
        if (health > 0)
        {
            Hearts[(Hearts.Length - health - 1)].SetActive(false);
        }
        else
        {
            StartCoroutine(stoptime());
        }
    }

    public IEnumerator stoptime()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        HeartCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        SoundManager.Instance.Play(Sounds.GameOver);
    }
}
