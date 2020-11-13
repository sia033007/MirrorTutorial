using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField PasswordField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name",nameField.text);
        form.AddField("password",PasswordField.text);
        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/register.php",form)){
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length>=8 && PasswordField.text.Length>=8);
    }
    
}
