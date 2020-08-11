using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
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
    public static string LOC_KEY_BUTTON_SAVE_NAME = "BUTTON_SAVE_NAME";
    public static string LOC_KEY_BUTTON_INCREASE_LEVEL = "BUTTON_INCREASE_5_LEVELS";
    public static string LOC_KEY_BUTTON_GETCURRENCY = "BUTTON_GET_CURRENCY";
    public static string LOC_KEY_BUTTON_PLAYER = "BUTTON_PLAYER";
    public static string LOC_KEY_BUTTON_ENEMY = "BUTTON_ENEMY";
    public static string LOC_KEY_TEXT_TITLE = "TEXT_TITLE";
    public static string LOC_KEY_TEXT_HELLO = "TEXT_HELLO";
    public static string LOC_KEY_TEXT_COUNTRY = "TEXT_COUNTRY";
    public static string LOC_KEY_TEXT_LEVEL = "TEXT_LEVEL";
    public static string LOC_KEY_BUTTON_ACHOICE = "BUTTON_ACHOICE";




    public static List<CSVTest> csvData;
    public static List<Dictionary<string, object>> csvResourceDictionary;
    public static List<Dictionary<string, object>> csvFileDictionary;
    public static Dictionary<string, Dictionary<string, string>> localizationDictionary;
    public static string currentLanguage = LOC_KEY_HEADER_LANGUAGE_ENGLISH;

    // Start is called before the first frame update
    void Awake()
    {

        if (StaticDataManager.LoadData())
        {
            Debug.Log("Static Data Load successful");
        }
        else
        {
            StaticDataManager.CreateDefaultData();
        }
        if (PersistentDataManager.LoadData())
        {
            Debug.Log("Persistent Data Load successful");

        }

        else
        {
            PersistentDataManager.CreateDefaultData();
            PersistentDataManager.SaveData();

        }
        LoadLocalizationData();
    }

    // Update is called once per frame
    private static void LoadLocalizationData()
    {
        localizationDictionary = new Dictionary<string, Dictionary<string, string>>();
        List<Dictionary<string, object>> loadLocList = CSVReader.ReadFromResources(LOCALIZATION_CSV_RESOURCE_FILENAME);
        if (loadLocList != null && loadLocList.Count > 0)
        {
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


    public void TestLoadCSVData()
    {
        csvData = CSVlloader.LoadCSVFromFile(Application.dataPath + Path.DirectorySeparatorChar + "Resources", SAMPLE_CSV_FILENAME);
        csvResourceDictionary = CSVReader.ReadFromResources(SAMPLE_CSV_RESOURCE_FILENAME);
        if (csvResourceDictionary.Count == csvData.Count)
        {
            if (csvData[0].Id == (int)csvResourceDictionary[0][RESOURCE_DB_SAMPLE_KEY_ID])
            {
                Debug.Log("Item 0 ID match in Loader and Resource Read");
            }
            if (csvData[2].Occupation == (string)csvResourceDictionary[2][RESOURCE_DB_SAMPLE_KEY_OCCUPATION])
            {
                Debug.Log("Item 2 Occupation match in Loader and Resource Read");
            }
        }

    }
    public void SavePlayerData()
    {
        PersistentDataManager.SaveData();
    }


    public void SelectLanguage(string langName)
    {
        currentLanguage = langName;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TestLoadCSVData();
        }
    }
}
