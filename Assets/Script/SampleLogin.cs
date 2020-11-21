using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SampleLogin : MonoBehaviour
{
    public InputField nameField;
    public InputField passField;
    public Button submitButton;

    public void Login()
    {
        StartCoroutine(loginPlayer());
    }
    IEnumerator loginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name",nameField.text);
        form.AddField("password",passField.text);
        using(UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/samplelogin.php",form))
        {
            yield return request.SendWebRequest();
            if(request.downloadHandler.text[0] == '0')
            {
                DBManager.username = nameField.text;
                DBManager.score = int.Parse(request.downloadHandler.text.Split('\t')[1]);
                DBManager.level = int.Parse(request.downloadHandler.text.Split('\t')[2]);
                Debug.Log("Log in successfully!");


            }
            else
            {
                Debug.Log("Failed to log in" + request.downloadHandler.text);
            }

        }
    }
     public void VeryfyInput()
    {
        submitButton.interactable = (nameField.text.Length>8 && passField.text.Length>8);
    }
   
}
