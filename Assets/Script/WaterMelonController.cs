using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class WaterMelonController : MonoBehaviour
{
    [SerializeField] GameObject m_halo;
    [SerializeField] int m_score = 1;
    [SerializeField] int m_plusTime;
    [SerializeField] GameObject m_text;
    bool IsScored = false;

    private void Awake()
    {
    }
    private void Start()
    {
        m_halo.SetActive(false);
        StartCoroutine("SetHalo");
        
    }

    IEnumerator SetHalo()
    {
        while (true)
        {
            if (gameObject.CompareTag("Fruits"))
            {
                m_halo.SetActive(false);
                if (!IsScored)
                {
                    GameManager.Instance.Point.Value += m_score;
                    GameManager.Instance.GameTime.Value += m_plusTime;
                    if (m_text != null)
                    {
                        Instantiate(m_text, new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z), this.transform.rotation);
                    }
                    IsScored = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Fruits")) return;
        if (other.CompareTag("CutArea"))
        {
            gameObject.tag = "Cut";
            m_halo.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.CompareTag("Fruits")) return;
        if (other.CompareTag("CutArea"))
        {
            gameObject.tag = "Cut";
            m_halo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Fruits")) return;
        if (other.CompareTag("CutArea"))
        {
            gameObject.tag = "Water";
            m_halo.SetActive(false);
        }
    }
}
