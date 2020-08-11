using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    //public GameController_Script gcs;
    // Start is called before the first frame update

    public const string RESOURCE_DB_SAMPLE_KEY_OCCUPATION = "Occupation";
    public const string RESOURCE_DB_SAMPLE_KEY_ID = "Id";

    public static string SAMPLE_CSV_FILENAME = "Sample.csv";
    public static string SAMPLE_CSV_RESOURCE_FILENAME = "Sample";
    public static string LOCALIZATION_CSV_RESOURCE_FILENAME = "Localization1";
    public static string LOC_KEY_HEADER_TEXT_ID = "Text_ID";
    public static string LOC_KEY_HEADER_LANGUAGE_ENGLISH = "EN";
    public static string LOC_KEY_HEADER_LANGUAGE_FRENCH = "FR";
    public static string LOC_KEY_HEADER_LANGUAGE_GERMAN = "DE";
    public static string LOC_KEY_HEADER_LANGUAGE_SPANISH = "ES";
    public static string LOC_KEY_BUTTON_SAVE_PLAYER = "BUTTON_SAVE_PLAYER";
    public static string LOC_KEY_BUTTON_LOAD_PLAYER = "BUTTON_LOAD_PLAYER";
    public static string LOC_KEY_BUTTON_MAIN_MENU = "BUTTON_MAIN_MENU";
    public static string LOC_KEY_BUTTON_PLAY = "BUTTON_PLAY";
    public static string LOC_KEY_TEXT_SCORE = "TEXT_SCORE";






    //public static List<csvtest> csvData;
    public static List<Dictionary<string, object>> csvResourceDictionary;
    public static List<Dictionary<string, object>> csvFileDictionary;
    public static Dictionary<string, Dictionary<string, string>> localizationDictionary;
    public static string currentLanguage = LOC_KEY_HEADER_LANGUAGE_ENGLISH;

    void Awake()
    {

        if (StaticDataManager.LoadData(Application.dataPath))
        {
            Debug.Log("Static Data Load successful");


        }
        else
        {
            StaticDataManager.CreateDefaultData();
            StaticDataManager.SaveGameData(Application.dataPath);
            //gcs.enemyBlue.Count = StaticDataManager.curGame.enemyBlue.Count;
        }
        if (PersistentManager.LoadData())
        {
            Debug.Log("Persistent Data Load successful");

        }

        else
        {
            PersistentManager.CreateDefaultData();
            PersistentManager.SaveData();

        }

        LoadLocalizationData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static void LoadLocalizationData()
    {
        localizationDictionary = new Dictionary<string, Dictionary<string, string>>();
        List<Dictionary<string, object>> loadLocList = csvreader.ReadFromResources(LOCALIZATION_CSV_RESOURCE_FILENAME);
        if (loadLocList == null)
        {
            Debug.Log("ERROR");
        }
        if (loadLocList != null && loadLocList.Count > 0)
        {
            Debug.Log("CSV file Load successful");

            foreach (Dictionary<string, object> translation in loadLocList)
            {
                Dictionary<string, string> curTranslation = new Dictionary<string, string>();
                foreach (string key in translation.Keys)
                {
                    if (key != LOC_KEY_HEADER_TEXT_ID)
                    {
                        curTranslation.Add(key, translation[key].ToString());
                    }
                }
                localizationDictionary.Add(translation[LOC_KEY_HEADER_TEXT_ID].ToString(), curTranslation);
            }
        }
    }

    public static string GetTranslation(string locKey, string languageKey)
    {
        if (localizationDictionary != null && localizationDictionary.Count > 0)
        {
            return localizationDictionary[locKey][languageKey];
        }
        return "";
    }


    //public void TestLoadCSVData()
    //{
    //    csvData = csvloader.LoadCSVFromFile(Application.dataPath + Path.DirectorySeparatorChar + "Resources", SAMPLE_CSV_FILENAME);
    //    csvResourceDictionary = csvreader.ReadFromResources(SAMPLE_CSV_RESOURCE_FILENAME);
    //    if (csvResourceDictionary.Count == csvData.Count)
    //    {
    //        if (csvData[0].Id == (int)csvResourceDictionary[0][RESOURCE_DB_SAMPLE_KEY_ID])
    //        {
    //            Debug.Log("Item 0 ID match in Loader and Resource Read");
    //        }
    //        if (csvData[2].Occupation == (string)csvResourceDictionary[2][RESOURCE_DB_SAMPLE_KEY_OCCUPATION])
    //        {
    //            Debug.Log("Item 2 Occupation match in Loader and Resource Read");
    //        }
    //    }

    //}

    public void SelectLanguage(string langName)
    {
        currentLanguage = langName;
    }

}
