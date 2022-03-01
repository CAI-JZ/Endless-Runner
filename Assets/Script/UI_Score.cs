using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    public Text Score;

    // Update is called once per frame
    void Update()
    {
        Score.text = string.Format("Score: {0}", cs_GameManager.Instance().Point);
    }
}
