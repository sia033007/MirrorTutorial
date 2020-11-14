using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button playButton;
    public Text playerDisplay;
    private void Start() {
        if(DBManager.LoggeIn)
        {
            playerDisplay.text = "Player : " + DBManager.username;
        }
        registerButton.interactable = !DBManager.LoggeIn;
        loginButton.interactable = !DBManager.LoggeIn;
        playButton.interactable = DBManager.LoggeIn;
        
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
   
   
}
