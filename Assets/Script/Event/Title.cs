using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Image image;

    public void Titlechange()
    {
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad()
    {
        float a = 0;
        while (a < 0.9)
        {
            a += 0.002f;
            image.color = new Color(0, 0, 0, a);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("MainScene");
    }
}
