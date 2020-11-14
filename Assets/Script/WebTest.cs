using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using(UnityWebRequest request = UnityWebRequest.Get("http://localhost/UnityMySQLTutorial/webtest.php"))
        {
            yield return request.SendWebRequest();
            string[] webResults = request.downloadHandler.text.Split('\t');
            Debug.Log(webResults[0]);
            int webNumber = int.Parse(webResults[1]);
            webNumber *= 2;
            Debug.Log(webNumber);
        }       
    }
}
