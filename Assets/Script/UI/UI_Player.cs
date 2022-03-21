using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public Text Score;

    // Update is called once per frame
    void Update()
    {
        Score.text = string.Format("Score: {0}", ScoreManager.Instance.Score);   
    }
}
