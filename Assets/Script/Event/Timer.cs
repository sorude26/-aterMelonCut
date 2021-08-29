using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Timer : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [SerializeField] Text m_timer;

    private void Awake()
    {
        m_gameManager.GameTime.Subscribe(_ => TimerText());
    }
    // Start is called before the first frame update
    
    void TimerText()
    {
        m_timer.text = m_gameManager.GameTime.Value.ToString();
    }
}
