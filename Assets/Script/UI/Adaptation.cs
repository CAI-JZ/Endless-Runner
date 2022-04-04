using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adaptation : MonoBehaviour
{
    [SerializeField]
    private CanvasScaler canvasScaler;
    
    private void Awake()
    {
        AdaptationManager.Instance.onScreenResize += OnScreenResize;
        Init();
    }

    private void OnDestroy()
    {
        AdaptationManager.Instance.onScreenResize -= OnScreenResize;
    }

    private void Init()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.matchWidthOrHeight = 0;
    }

    private void OnScreenResize()
    {
        if (AdaptationManager.Instance.actualRatio > AdaptationManager.Instance.defaultRatio)
        {
            canvasScaler.matchWidthOrHeight = 1;
        }
        else
        {
            canvasScaler.matchWidthOrHeight = 0;
        }
    }
}
