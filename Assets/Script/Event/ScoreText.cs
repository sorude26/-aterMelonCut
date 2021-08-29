using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class ScoreText : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [SerializeField] Text m_scoreText;
    [SerializeField] GameObject m_lastScorepos;
    // Start is called before the first frame update
    void Start()
    {
        m_gameManager.Point.Subscribe(_ => ScoreChange());
        m_gameManager.GameEnd.Subscribe(_ => LastScore());
        m_scoreText.GetComponent<Text>();
    }


    void ScoreChange()
    {
        m_scoreText.text = m_gameManager.Point.Value.ToString();
    }

    void LastScore()
    {
        m_scoreText.transform.position = m_lastScorepos.transform.position;
        m_scoreText.fontSize = 100;
    }
}
