using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetUsers());
        StartCoroutine(Login("testuser", "12345"));
        
    }
    IEnumerator GetDate()
    {
        using(UnityWebRequest request = UnityWebRequest.Get("http://localhost/UnityBackendTutorial/GetDate.php"))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                byte[] results = request.downloadHandler.data;
            }
        }
    }
    IEnumerator GetUsers()
    {
        using(UnityWebRequest request = UnityWebRequest.Get("http://localhost/UnityBackendTutorial/GetUsers.php"))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                byte[] results = request.downloadHandler.data;
            }
        }
    }
     IEnumerator Login(string username , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", "username");
        form.AddField("loginPass", "password");


        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityBackendTutorial/login.php", form))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}
