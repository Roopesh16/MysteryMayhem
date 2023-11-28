using UnityEngine;

public static class JsonLoader
{
    public static string LoadJson(string loadPath)
    {
        TextAsset data = Resources.Load<TextAsset>(loadPath);
        return data.text;
    }
}

