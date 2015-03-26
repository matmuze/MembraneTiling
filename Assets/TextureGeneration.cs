using UnityEngine;
using System.Collections;
using UnityEditor;

// Debug function to instanciate molecules in edit mode
public static class MyMenuCommands
{
    [MenuItem("My Commands/Create texture &a")]
    static void FirstCommand()
    {
        int n = 64;
        int size = n * n;
        Color[] volumeColors = new Color[size];


        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                int idx = x + y*n;

                float rand = UnityEngine.Random.Range(0.0f, 1.0f);

                if (rand < 0.05f)
                {
                    volumeColors[idx] = Color.black;
                }
                else
                    volumeColors[idx] = Color.white;
                
            }
        }

        var texture2D = new Texture2D(n, n, TextureFormat.ARGB32, false);
        texture2D.SetPixels(volumeColors);
        texture2D.Apply();

        string path = "Assets/texture_noise.asset";

        AssetDatabase.CreateAsset(texture2D, path);
        AssetDatabase.SaveAssets();

        // Print the path of the created asset
        Debug.Log(AssetDatabase.GetAssetPath(texture2D));
    }
}


public class TextureGeneration : MonoBehaviour
{
    // Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
