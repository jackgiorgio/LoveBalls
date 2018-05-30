using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RenderTextToPNG : MonoBehaviour {

    private RenderTexture rt;

    private void Start()
    {
        rt = GetComponent<Camera>().targetTexture;
    }

    public void SaveToPNG(int level)
    {
        string levelString = level.ToString() + ".png";

        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = rt; ;

        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        byte[] bytes = tex.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/Resources/LevelScreenshots/Screenshot_" + levelString, bytes);
        File.WriteAllBytes(Application.persistentDataPath + "/Screenshot_" + levelString, bytes);
        Debug.Log("convert successful!");
    }


    public void SaveToDefaultPNG(int level)
    {
        string levelString = level.ToString() + ".png";
        rt = GetComponent<Camera>().targetTexture;
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = rt; ;

        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        byte[] bytes = tex.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/Resources/LevelScreenshots/Default_" + levelString, bytes);
        File.WriteAllBytes(Application.persistentDataPath + "/Default_" + levelString, bytes);
        Debug.Log("convert successful!");
    }
}
