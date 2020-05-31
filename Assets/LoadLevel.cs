using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float delay = 5f;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    void Start()
    {
        StartCoroutine(LoadMainLevel());
    }

    private IEnumerator LoadMainLevel()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
