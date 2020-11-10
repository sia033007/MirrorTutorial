using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssets : MonoBehaviour
{
    public GameObject spawn;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAssetBundle(path));
        
    }
    IEnumerator LoadAssetBundle(string path)
    {
        using(UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path))
        {
            yield return request.SendWebRequest();

            AssetBundle asset = DownloadHandlerAssetBundle.GetContent(request);
            var prefab = asset.LoadAsset("Amin");
            GameObject player = Instantiate(prefab,spawn.transform.position,spawn.transform.rotation) as GameObject;
            player.transform.SetParent(spawn.transform);

        }
    }
}
