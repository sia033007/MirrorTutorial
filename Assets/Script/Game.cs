using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDislay;
    private void Awake() {

        if(DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Player : " + DBManager.username;
        scoreDislay.text = "Score : " + DBManager.score;
    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name",DBManager.username);
        form.AddField("score",DBManager.score);
        using(UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/savedata.php",form))
        {
            yield return request.SendWebRequest();
            if(request.downloadHandler.text == "0")
            {
                Debug.Log("Game Saved");
            }
            else
            {
                Debug.Log("Save failed" + request.downloadHandler.text);
            }
            DBManager.LogOut();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }
    public void increaseScore()
    {
        DBManager.score++;
        scoreDislay.text = "Score : " + DBManager.score;
    }
}
