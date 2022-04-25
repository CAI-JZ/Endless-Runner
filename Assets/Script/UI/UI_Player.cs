using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public Text Score;
    void Update()
    {
        Score.text = string.Format("Score: {0}", ScoreManager.Instance().Score );   
    }
}
