﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathFromFalling : MonoBehaviour
{
    [SerializeField] private GameManage gameManage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
           
            gameManage.StartCoroutine("stoptime");

        }
    }
}
