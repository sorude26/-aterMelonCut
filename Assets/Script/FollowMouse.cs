using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [SerializeField] GameObject m_cutArea;
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
    bool m_cutMode;
    IDisposable m_input;
    private void Awake()
    {
        m_gameManager.InGame.Subscribe(_ =>
        {
            m_input = this.UpdateAsObservable().Subscribe(_2 =>
            {
                if (Input.GetButton("Fire1"))
                {
                    if (!m_cutMode)
                    {
                        m_cutMode = true;
                        m_cutArea.SetActive(true);
                    }
                    return;
                }
                position = Input.mousePosition;
                position.z = 10f;
                screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
                gameObject.transform.position = screenToWorldPointPosition;
                if (m_cutMode)
                {
                    m_cutMode = false;
                    m_cutArea.SetActive(false);
                    SoundManager.Instance.PlaySE(SEType.Cut);
                }
            });
        });
        m_gameManager.GameEnd.Subscribe( _ =>
        {
            m_input.Dispose();
            m_cutMode = false;
            m_cutArea.SetActive(false);
        });
    }
    private void Start()
    {
        m_cutMode = false;
        m_cutArea.SetActive(false);
    }
}
