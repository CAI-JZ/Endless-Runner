using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveData(string SaveFileName, object SaveFileData)
    {
        var json = JsonUtility.ToJson(SaveFileData);
        var path = Path.Combine(Application.persistentDataPath, SaveFileName);

        try
        {
            File.WriteAllText(path, json);
            Debug.Log($"Susscessfully saved data to {path}.");
#if UNITY_EDITOR
            Debug.Log($"Susscessfully saved data to {path}.");
            #endif
        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to save data to {path}. \n{exception}");
            #endif
        }
    }

    public static T LoadData<T>(string SaveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, SaveFileName);
        
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch(System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to load data from {path}. \n{exception}");
            #endif
            return default;
        }
    }

    public static void DeleteSaveFile(string SaveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, SaveFileName);
   
        try
        {
            File.Delete(path);
        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to delete data: {path}. \n{exception}");
            #endif
            
        }
    }

    // Check is file exist
    public static bool SaveFileExist(string SaveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, SaveFileName);

        return File.Exists(path);
    }
}