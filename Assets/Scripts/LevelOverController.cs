using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private GameObject LevelOverCanvas;
    [SerializeField] public GameObject player;
    private void Awake()
    {
        LevelOverCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
           
            LevelOverCanvas.SetActive(true);
            SoundManager.Instance.Play(Sounds.Teleporter);
            player.SetActive(false);
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}

