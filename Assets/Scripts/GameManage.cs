using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [SerializeField] private GameObject Heart1, Heart2, Heart3;
    [SerializeField] private GameObject HeartCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] public GameObject player;

    private void Awake()
    {
        HeartCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
    }
    public void Heart(float health)
    {
        if (health > 3)
        {
            health = 3;
        }
        switch (health)
        {
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                StartCoroutine(stoptime());
                break;
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
