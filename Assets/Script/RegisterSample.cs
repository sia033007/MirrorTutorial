using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegisterSample : MonoBehaviour
{
    public InputField nameField;
    public InputField passField;
    public Button submitButton;
    public void Register()
    {
        StartCoroutine(Registration());
    }
    IEnumerator Registration()
    {
        WWWForm form = new WWWForm();
        form.AddField("name",nameField.text);
        form.AddField("password",passField.text);
        using(UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityMySQLTutorial/registersample.php",form))
        {
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }

        }
    }
    public void VeryfyInput()
    {
        submitButton.interactable = (nameField.text.Length>8 && passField.text.Length>8);
    }
}
