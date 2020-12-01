using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestHighscore : MonoBehaviour
{
    public GameObject highscoreObject;
    public InputField userInput;
    public void Savescore() {
        HighScores.AddNewHighscore(userInput.text,DBManager.score);
        StartCoroutine(disableObject());
        
    }
    IEnumerator disableObject()
    {
        yield return new WaitForSeconds(1f);
        highscoreObject.SetActive(false);
    }
}
