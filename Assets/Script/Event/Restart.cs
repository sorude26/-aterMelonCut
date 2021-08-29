using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    private void Awake()
    {
        m_gameManager.GameEnd.Subscribe(_ => End()).AddTo(this);
        this.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Soezima");
    }

    void End()
    {
        this.gameObject.SetActive(true);
    }
}
