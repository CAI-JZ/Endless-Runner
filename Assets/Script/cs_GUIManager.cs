using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_GUIManager : MonoBehaviour
{
    public CanvasGroup CanvasGroup;

    private float FadeSpeed = 0.1f;

    public void ShowUI()
    {
        StartCoroutine(Show());
    }

    public void HideUI()
    {
        StartCoroutine(Hide());
        gameObject.SetActive(false);
    }

    private IEnumerator Hide()
    {
        while (CanvasGroup.alpha > 0)
        {
            CanvasGroup.alpha -= FadeSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator Show()
    {
        while (CanvasGroup.alpha < 1)
        {
            CanvasGroup.alpha += FadeSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    
}
