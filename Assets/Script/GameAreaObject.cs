using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaObject : MonoBehaviour
{
    [Header("範囲外に出たら破壊するタグの名前")]
    [SerializeField] string m_areaName = "GameArea";
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == m_areaName)
        {
            Destroy(this.gameObject);
        }
    }
}
