using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [SerializeField] Text m_countDown;

    private void Awake()
    {
        m_gameManager.GameStart.Subscribe(_ => StartCoroutine(GameStartCount())).AddTo(this);
        m_gameManager.GameEnd.Subscribe(_ => GameEnd()).AddTo(this);
    }

    IEnumerator GameStartCount()
    {
        int count = 4;
        while(count >= 0)
        {
            count--;
            if (count == 0)
            {
                m_countDown.text = "Start";
                yield return new WaitForSeconds(1);
                break;
            }
            m_countDown.text = count.ToString();
            yield return new WaitForSeconds(1);
        }
        this.gameObject.SetActive(false);
    }

    void GameEnd()
    {
        this.gameObject.SetActive(true);
        m_countDown.text = "End";
    }
}
