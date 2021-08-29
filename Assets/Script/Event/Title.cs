using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] string m_scene;

    public void Titlechange()
    {
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad()
    {
        float a = 0;
        while (a < 0.9)
        {
            a += 0.004f;
            image.color = new Color(0, 0, 0, a);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(m_scene);
    }
}
