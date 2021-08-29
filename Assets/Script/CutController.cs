﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLINDED_AM_ME;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class CutController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_cutObjects = null;
    [SerializeField] private GameObject m_effect = null;
    [SerializeField] private GameObject m_cutplane = null;
    [SerializeField] private Material m_cutMaterial = null;
    [SerializeField] private float m_cutPower = 3f;
    [SerializeField]LineRenderer lineRenderer;
    Vector3 worldPos;
    Vector3 pos;
    public bool m_cutMode = true;
    GameObject[] cutObjects;
    bool IsFirst = true;
    Vector3[] col;
    
    // Start is called before the first frame update
    void Start()
    {
        IsFirst = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lineRenderer);
        pos = Input.mousePosition;
        m_cutObjects = GameObject.FindGameObjectsWithTag("Cut");
    }

    public void CutObject(bool cutMode)
    {
        GameManager.Instance.Point.Value += 100;
        Debug.Log(m_cutplane.transform.rotation.z);
        Vector3 cut = Vector3.zero;
        if (cutMode)
        {
            cut = new Vector3(1, -m_cutplane.transform.rotation.z, 0);
        }
        else
        {
            if (lineRenderer.GetPosition(1) != null)
            {
                cut = new Vector3((lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).y, -(lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).x, 0);
            }
        }
        if (m_cutObjects == null) return;
        foreach (var item in m_cutObjects)
        {
            cutObjects = MeshCut.Cut(item, item.transform.position, cut, m_cutMaterial);
            Instantiate(m_effect, item.transform.position, item.transform.rotation);
        }
        if (cutObjects == null) return;
    }

    public void OnBeginDrag()
    {
        pos.z = 1;
        worldPos = Camera.main.ScreenToWorldPoint(pos);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,new Vector3(worldPos.x, worldPos.y,1));
    }

    public void OnEndDrag()
    {
        pos.z = 1;
        worldPos = Camera.main.ScreenToWorldPoint(pos);
        lineRenderer.SetPosition(1, new Vector3(worldPos.x, worldPos.y, 1));
        IsFirst = false;
        CutObject(m_cutMode);
    }
}
