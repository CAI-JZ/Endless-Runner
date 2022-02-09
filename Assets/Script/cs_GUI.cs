using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_GUI : MonoBehaviour
{
    cs_GameManager instance;

    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + cs_GameManager.Instance.Point;
    }
}
