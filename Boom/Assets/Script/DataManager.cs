using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static string LOCALIZATION_CSV_RESOURCE_FILENAME = "LocalizationCSV";
    public static string LOC_KEY_HEADER_TEXT_ID = "TEXT_ID";
    public static string LOC_KEY_BUTTON_SAVE_PLAYER = "BUTTON_SAVE_PLAYER";
    public static string LOC_KEY_BUTTON_LOAD_PLAYER = "BUTTON_LOAD_PLAYER";
    public static string LOC_KEY_BUTTON_NEXT_LEVEL = "BUTTON_NEXT_LEVEL";
    public static string LOC_KEY_TEXT_SCORE = "TEXT_SCORE";
    public static string LOC_KEY_HEADER_LANGUAGE_ENGLISH = "EN";
    public static string currentLanguage = LOC_KEY_HEADER_LANGUAGE_ENGLISH;
    public static List<Dictionary<string, object>> csvResourceDictionary;
    public static List<Dictionary<string, object>> csvFileDictionary;
    public static Dictionary<string, Dictionary<string, string>> localizationDictionary;
    public static string LOC_KEY_HEADER_LANGUAGE_FRENCH = "FR";


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

    public void SelectLanguage(string langName)
    {
        currentLanguage = langName;
    }
    // Start is called before the first frame update
    void Awake()
    {
        LoadLocalizationData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
