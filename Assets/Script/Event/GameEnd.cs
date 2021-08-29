using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.SceneManagement;


public class GameEnd : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [SerializeField] string m_sceneName;
    [SerializeField]bool m_isEndless;
    private void Awake()
    {
        m_gameManager.GameEnd.Subscribe(_ => End()).AddTo(this);
        if (!m_isEndless)
        this.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(m_sceneName);
    }

    void End()
    {
        this.gameObject.SetActive(true);
    }
}
