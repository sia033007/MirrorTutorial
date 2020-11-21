using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
    public Text[] highscoreText;
    HighScores highscoremanager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i+1 + ". Fetching...";     
        }
        highscoremanager = GetComponent<HighScores>();
        StartCoroutine(RefreshHighscores());
        
    }
    public void OnHighscoreDownload(HighScores.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i+1 + ". ";
            if(highscoreList.Length>i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }     
        }
    }
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoremanager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
