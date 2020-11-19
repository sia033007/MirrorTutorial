﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SampleGame : MonoBehaviour
{
    public Text userDisplay;
    public Text scoreDisplay;

    private void Awake() {
        userDisplay.text = "Username : " + DBManager.username;
        scoreDisplay.text = "Score : " + DBManager.score;
    }
    public void saveData()
    {
        StartCoroutine(dataSave());
    }
    IEnumerator dataSave()
    {
        WWWForm form = new WWWForm();
        form.AddField("name",DBManager.username);
        form.AddField("score",DBManager.score);
        using(UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/samplegame.php",form))
        {
            yield return request.SendWebRequest();
            if(request.downloadHandler.text == "0")
            {
                Debug.Log("Game saved");
            }
            else
            {
                Debug.Log("Save failed" + request.downloadHandler.text);
            }
        }
    }
    public void increaseScore()
    {
        DBManager.score++;
        scoreDisplay.text = "Score : " + DBManager.score;
    }
    
}
