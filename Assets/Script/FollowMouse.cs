using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] GameObject m_cutArea;
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
    bool m_cutMode;
    private void Start()
    {
        m_cutMode = false;
        m_cutArea.SetActive(false);
    }
    void Update()
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
        }
    }
}
