using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HighScore : MonoBehaviour
{
    List<HighScoreEntry> Scores = new List<HighScoreEntry>();

    public void AddScore(string newName, float newScore)
    {
        Scores.Add(new HighScoreEntry { UserName = newName, Score =newScore });
    }

}
