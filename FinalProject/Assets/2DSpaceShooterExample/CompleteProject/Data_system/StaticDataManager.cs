using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StaticDataManager
{

    public static string PREF_KEY_JSON_SAVE = "GameDataJson";
    public static GameData curGame;
    public static string GAMEDATA_FILENAME_PREFIX = "GameData";
    public static string GAMEDATA_FILENAME_JSON_EXT = ".json";


    private static bool LoadFromJson(string filename)
    {
        string jsonString = File.ReadAllText(filename);
         Debug.Log("Loading Json: " + jsonString );
        if (!string.IsNullOrEmpty(jsonString))
        {
            GameData tempObj = JsonUtility.FromJson<GameData>(jsonString);
            if (tempObj != null)
            {
                curGame = tempObj;
                return true;
            }
            else
            {
                return false;
            }
        }
        else {
            return false;
        }
    }

    public static bool LoadData(string path)
    {
        string filename = path + Path.DirectorySeparatorChar + GAMEDATA_FILENAME_PREFIX + GAMEDATA_FILENAME_JSON_EXT;
        if (File.Exists(filename))
        {
            bool isLoaded = LoadFromJson(filename);
            if (isLoaded)
            {
                Debug.Log("Game Data Loaded: " + curGame.ToString());

            }
            return isLoaded;
        }
        else
        {
            Debug.LogWarning("GameData not loaded. File Not Found: " + filename);
            return false;
        }
    }

    public static void CreateDefaultData()
    {
        curGame =new GameData();
        curGame.Enemycount = 10;
      
    }

    private static bool SaveToJson(string filename)
    {
        if (curGame != null)
        {
            string jsonString = JsonUtility.ToJson(curGame);
            if (string.IsNullOrEmpty(filename))
            {
                PlayerPrefs.SetString(PREF_KEY_JSON_SAVE, jsonString);


            }
            else
            {

                File.WriteAllText(filename, jsonString);
            }
            return true;

        }
        else
        {
            return false;
        }
    }

    public static bool SaveGameData(string path)
    {
        if (curGame == null)
        {
            CreateDefaultData();
        }
        if(curGame!=null)
        {
            string filename = path + Path.DirectorySeparatorChar + GAMEDATA_FILENAME_PREFIX + GAMEDATA_FILENAME_JSON_EXT;
            if (!string.IsNullOrEmpty(filename))
            {
                string jsonString = JsonUtility.ToJson(curGame, true);
                File.WriteAllText(filename, jsonString);

                return File.Exists(filename);
            }
        }
        return false;
    }



}
