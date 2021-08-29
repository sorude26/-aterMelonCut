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
    // Start is called before the first frame update
    void Start()
    {
        m_gameManager.Point.Subscribe(_ => ScoreChange());
    }


    void ScoreChange()
    {
        m_scoreText.text = m_gameManager.Point.Value.ToString();
    }
}
