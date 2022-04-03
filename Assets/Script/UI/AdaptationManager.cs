using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptationManager : MonoBehaviour
{
    private static AdaptationManager instance;

    public static AdaptationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("AdaptationManager").AddComponent<AdaptationManager>();
                instance.Init();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public int defaultWidth = 720;
    public int defaultHeight = 1280;

    public ResizeType resizeType = ResizeType.OnScreenChange;

    [HideInInspector] public float defaultRatio; //Ĭ����ƵĿ�߱�
    [HideInInspector] public float actualRatio; //ʵ����Ļ�Ŀ�߱�
    [HideInInspector] public Vector2 screenSize; //��Ļʵ�ʷֱ���

    public Action onScreenResize;

    private void OnEnable()
    {
        if (resizeType == ResizeType.OnEnable)
        {
            RefreshData();
        }
    }

    private void Start()
    {
        if (resizeType == ResizeType.OnStart)
        {
            RefreshData();
        }
    }

    private void Update()
    {
        if (resizeType == ResizeType.OnScreenChange)
        { 
            Vector2 tempSize = new Vector2(Screen.width, Screen.height);
            if (screenSize != tempSize)
            {
                screenSize = tempSize;
                RefreshData();
            }
        }
    }

    private void Init()
    {
        defaultRatio = defaultWidth * 1f / defaultHeight;
        actualRatio = Screen.width * 1f / Screen.height;
        
    }

    private void RefreshData()
    {
        actualRatio = Screen.width * 1f / Screen.height;
        onScreenResize?.Invoke();
        print(1);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
