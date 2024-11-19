using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoadSystemData
{
    public static void SaveData <T>(T data, string path, string fileName)
    {
        string fullPath = Application.persistentDataPath + "/" + path + "/";
        bool checkFolderExit = Directory.Exists(fullPath);
        if (!checkFolderExit)
        {
            Directory.CreateDirectory(fullPath);
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath + fileName + ".json", json);
        Debug.Log("Se guardaron los datos en " + fullPath);
    }
    public static T LoadData<T>(string path, string fileName)
    {
        string fullpath = Application.persistentDataPath + "/" + path + "/" + fileName + ".json";
        if (File.Exists(fullpath))
        {
            string textJson = File.ReadAllText(fullpath);
            var obj = JsonUtility.FromJson<T>(textJson);
            return obj;
        }
        else
        {
            Debug.Log("No existe ese archivo oara cargar los datos");
            return default;
        }
    }        
}
