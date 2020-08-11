using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDataManager
{
    public static string PREF_KEY_JSON_SAVE = "GameDataJson";
    private static BaseGame curGame;
    public static Vector3 position;
    public static Enemy enemy;
    public static Player player;
    private static bool LoadFromJson(string filename)
    {
        string jsonString = PlayerPrefs.GetString(PREF_KEY_JSON_SAVE);
        Debug.Log("Loading Json: " + jsonString);
        BaseGame tempObj = JsonUtility.FromJson<BaseGame>(jsonString);
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
    public static bool LoadData()
    {
        bool isLoaded = LoadFromJson("");
        if (isLoaded)
        {
            Debug.Log("Game Data Loaded: " + curGame.ToString());
        }
        return isLoaded;
    }

    // Should never be called in production
    public static void CreateDefaultData()
    {
        curGame = new BaseGame();
        enemy = new Enemy();
        player = new Player();
        enemy.number = 10;
        enemy.type = "Ranged";
        player.curId = "A1";
        player.Currency = 100;
        player.Name = "John";
        player.score = 10;
        position = new Vector3(0, 0, 0);
        curGame.avatar_Choices = 2;
        curGame.levelNum = 3;
        curGame.start_Value = 10;
        curGame.obstacles_Num = 100;
        curGame.spawnPosition.Add(position);
        curGame.enemies.Add(enemy);
        curGame.players.Add(player);
        SaveGameData();
    }

    // Should never be called in production
    private static bool SaveToJson(string filename)
    {
        if (curGame != null)
        {
            string jsonString = JsonUtility.ToJson(curGame);
            PlayerPrefs.SetString(PREF_KEY_JSON_SAVE, jsonString);
            return true;
        }
        else
        {
            return false;
        }
    }
    // Should never be called in production
    public static bool SaveGameData()
    {
        bool isSaved = SaveToJson("");
        if (isSaved)
        {
            Debug.Log("Player saved: " + curGame.ToString() );
        }

        return isSaved;
    }

    public static Player GetStartingPlayerData()
    {
        if (curGame != null)
        {
            foreach (Player curPlayerData in curGame.players)
            {
                if (curPlayerData != null)
                { 
                return curPlayerData;
            }

            }
        }
        return null;
    }
}
