using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PersistentDataManager 
{
    private static BaseGame curGame;
    public static Vector3 position;
    public static Enemy enemy;
    public static Player player;
    public static void ClearSaveData()
    {
        PlayerPrefs.DeleteKey("GameDataJson");
        CreateDefaultData();

    }
    private static string GetDefaultJsonFilename(string userrName)
    {
        string filename = Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData_"
            + userrName + ".json";

        return filename;



    }



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

    }

    public static bool LoadData()
    {
        string filename = GetDefaultJsonFilename("Game1");
        bool isLoaded = LoadFromJson(filename);
        if (isLoaded)
        {
            Debug.Log("Game Loaded" + curGame.levelNum);
        }

        return isLoaded;
     }

    public static bool LoadFromJson(string filename)
    {
        string jsonString = "";
        if (string.IsNullOrEmpty(filename))
        {
            jsonString = PlayerPrefs.GetString("GameDataJson");

        }
        else {
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
                Debug.LogError("Error: Attempting to load Game Data from " + filename);
                return false;
            }
        }
            
       
        Debug.Log("Loading Json: " + jsonString);
        BaseGame temobj = JsonUtility.FromJson<BaseGame>(jsonString);

        if (temobj != null)
        {
            curGame = temobj;
            return true;

        }
        else {
            return false;
        }


    }


    public static bool SaveData()
    {
        string filename = GetDefaultJsonFilename("Game1");
        bool isSaved = SaveToJson(filename);
        if (isSaved)
        {
            Debug.Log("Game Saved: " + curGame.ToString());
            
        }
        return isSaved;

    }
    private static bool SaveToJson(string filename)
    {
        if (curGame != null)
        {
            string jsonString = JsonUtility.ToJson(curGame);
            if (string.IsNullOrEmpty(filename))
            {
                PlayerPrefs.SetString("GameDataJson", jsonString);


            }
            else
            {

                File.WriteAllText(filename, jsonString);
            }
            return true;

        }
        else {
            return false;
        }

    }
    public static string GetName()
    {
        if (curGame != null)
        {
            foreach (Player _currentPlayer in curGame.players)
            {
                if (_currentPlayer != null)
                {
                    return _currentPlayer.Name;
                }
                else
                {
                    return "NULL";
                }
            }
        }
        return "NULL";
    }

    public static void ChangeCurrency(int valueChange)
    {
        foreach (Player _currentPlayer in curGame.players)
        {
            bool isFound = false;
            if (_currentPlayer != null)
            {
                _currentPlayer.Currency += valueChange;
                isFound = true;
                break;
            }

            if (!isFound)
            {
                Player newPlayer = new Player();

                newPlayer.Currency = valueChange;

            }
            SaveData();

        }

    }
    public static int GetGameLevel()
    {
        if (curGame != null)
        {

            return curGame.levelNum;

        }
        return 0;


    }

    public static void IncreaseGameLevel(int num)
    {
        if (curGame != null)
        {
            curGame.levelNum += num;
            SaveData();


        }



    }

    public static int GetCurrency()
    {
        foreach (Player _currentPlayer in curGame.players)
        {
            if (_currentPlayer != null)
            {
                return _currentPlayer.Currency;
     
             }
            
        }
        return 0;
    }

    public static void UpdatePlayerData(string newName)
    {
        foreach (Player _currentPlayer in curGame.players)
        {
            if (_currentPlayer != null)
            {
                _currentPlayer.Name = newName;
                SaveData();
            }
        }
    }

}
