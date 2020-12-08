using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathFX;
    
    void OnTriggerEnter(Collider other)
    {
        StartDeathSeqence();

    }

    private void StartDeathSeqence()
    {
        SendMessage("FreezeControls");
        deathFX.SetActive(true);
        Invoke("ReLoadLevel", levelLoadDelay);
    }
    private void ReLoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
