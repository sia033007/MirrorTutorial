using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Assetmanager : Editor
{
   [MenuItem("Assets/Build AssetBundle")]
   public static void BuildAssetBundle()
   {
       BuildPipeline.BuildAssetBundles(@"C:\Users\HeisenBerg\Desktop\Server",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.StandaloneWindows64);
   }

}
