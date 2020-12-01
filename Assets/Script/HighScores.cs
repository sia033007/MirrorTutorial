using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    const string privateCode = "9iXRUckajUOM1iq60VfHXARYwtNgkhTkatgM_NZ-IAjg";
    const string publicCode = "5fba1d5deb36fd2714d9a0e7";
    const string webURL = "http://dreamlo.com/lb/";
    public Highscore[] highscoreslist;
    DisplayHighscores highscoresDisplay;
    static HighScores instance;

    private void Awake() {
        highscoresDisplay = GetComponent<DisplayHighscores>();
        instance = this;
    }

    public static void AddNewHighscore(string username , int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username , score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        UnityWebRequest request = new UnityWebRequest(webURL + privateCode + "/add/"  + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return request.SendWebRequest();
        if(request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Successfully added");
            DownloadHighscores();
        }
    }
    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoreFromDatabase());
    }
    IEnumerator DownloadHighscoreFromDatabase()
    {
        UnityWebRequest request = new UnityWebRequest(webURL + publicCode + "/pipe/");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        if(request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            FormatHighscores(request.downloadHandler.text);
            highscoresDisplay.OnHighscoreDownload(highscoreslist);
        }
    }
    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreslist = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryinfo = entries[i].Split(new char[] {'|'});
            string username = entryinfo[0];
            int score = int.Parse(entryinfo[1]);
            highscoreslist[i] = new Highscore(username,score);
            print(highscoreslist[i].username + ": " + highscoreslist[i].score);
            
        }
    }
    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username , int _score)
        {
            username = _username;
            score = _score;
        }
        
    }
}
