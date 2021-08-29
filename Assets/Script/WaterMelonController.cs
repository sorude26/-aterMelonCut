using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelonController : MonoBehaviour
{
    [SerializeField] GameObject m_halo;
    private void Start()
    {
        m_halo.SetActive(false);
        StartCoroutine("SetHalo");
    }

    IEnumerator SetHalo()
    {
        while (true)
        {
            if (gameObject.CompareTag("Fruits")) m_halo.SetActive(false);
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
