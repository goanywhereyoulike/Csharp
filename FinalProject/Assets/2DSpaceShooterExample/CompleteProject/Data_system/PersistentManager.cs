using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentManager 
{

    public static PlayerData curPlayer;
    public static void ClearSaveData()
    {
        PlayerPrefs.DeleteKey("PlayerDataJson");
        CreateDefaultData();

    }
    private static string GetDefaultJsonFilename(string userrName)
    {
        string filename = Application.persistentDataPath + Path.DirectorySeparatorChar + "PlayerData_"
            + userrName + ".json";

        return filename;



    }



    public static void CreateDefaultData()
    {
        curPlayer = new PlayerData();
        curPlayer.health = 100;
        curPlayer.speed = 6f;
        curPlayer.fireRate = 0.5f;
        curPlayer.Score = 0;

    }

    public static bool LoadData()
    {
        string filename = GetDefaultJsonFilename("Player1");
        bool isLoaded = LoadFromJson(filename);
        if (isLoaded)
        {
            Debug.Log("Player Data Loaded" + curPlayer.ToString());
        }

        return isLoaded;
    }

    public static bool LoadFromJson(string filename)
    {
        string jsonString = "";
        if (string.IsNullOrEmpty(filename))
        {
            jsonString = PlayerPrefs.GetString("PlayerDataJson");

        }
        else
        {
            if (File.Exists(filename))
            {
                jsonString = File.ReadAllText(filename);
            }
            else
            {
                Debug.LogError("Error: File " + filename + " does not exist!");
                return false;
            }
            if (string.IsNullOrEmpty(jsonString))
            {
                Debug.LogError("Error: Attempting to load Player Data from " + filename);
                return false;
            }
        }


        Debug.Log("Loading Json: " + jsonString);
        PlayerData temobj = JsonUtility.FromJson<PlayerData>(jsonString);

        if (temobj != null)
        {
            curPlayer = temobj;
            return true;

        }
        else
        {
            return false;
        }


    }


    public static bool SaveData()
    {
        string filename = GetDefaultJsonFilename("Player1");
        bool isSaved = SaveToJson(filename);
        if (isSaved)
        {
            Debug.Log("Player1 Saved: " + curPlayer.ToString());

        }
        return isSaved;

    }
    private static bool SaveToJson(string filename)
    {
        if (curPlayer != null)
        {
            string jsonString = JsonUtility.ToJson(curPlayer);
            if (string.IsNullOrEmpty(filename))
            {
                PlayerPrefs.SetString("PlayerDataJson", jsonString);


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
   

    public static void UpdatePlayerData(int health,  int score)
    {

         if (curPlayer != null)
            {
            curPlayer.health = health;
            curPlayer.Score = score;

            SaveData();
            }
       
    }

    public static void LoadPlayerData()
    {
        if (curPlayer != null)
        {
            LoadData();

        }


    }

}
