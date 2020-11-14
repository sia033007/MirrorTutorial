using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    
    public InputField nameField;
    public InputField PasswordField;
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }
    IEnumerator LoginPlayer()
    {
         WWWForm form = new WWWForm();
        form.AddField("name",nameField.text);
        form.AddField("password",PasswordField.text);
        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/login.php",form)){
        yield return request.SendWebRequest();
        if(request.downloadHandler.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(request.downloadHandler.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Debug.Log("Successfully loaded!");
        }
        else
        {
            Debug.Log("User login failed" + request.downloadHandler.text);
        }

        }

    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length>=8 && PasswordField.text.Length>=8);
    }
}
