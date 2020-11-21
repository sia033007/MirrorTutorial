using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestHighscore : MonoBehaviour
{
    public int score =50;
    public InputField userInput;

    public void UpdateHighscore()
    {
        HighScores.AddNewHighscore(userInput.text,score);
    }
}
