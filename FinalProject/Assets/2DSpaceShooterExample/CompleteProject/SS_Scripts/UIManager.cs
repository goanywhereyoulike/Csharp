using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public static bool GamePause = false;
    public GameObject puasemanu;
    public Button SaveButton;
    public Button LoadButton;
    public Text SaveText;
    public Text LoadText;
    public Text Score;
    public Text MainManu;
 
    public Dropdown languageDropDown;

    // Start is called before the first frame update
    void Start()
    {
        if (languageDropDown != null)
        {
            languageDropDown.ClearOptions();
            List<string> langNames = new List<string>();
            langNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_ENGLISH);
            langNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_FRENCH);
            langNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_GERMAN);
            langNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_SPANISH);
            languageDropDown.AddOptions(langNames);
            languageDropDown.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        puasemanu.SetActive(false);
        Time.timeScale = 1f;
      
        GamePause = false;

    }

    void Pause()
    {
        puasemanu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }


    public void LoadmainManu()
    {

        SceneManager.LoadScene("MainManu");

    }
    public void SelectLanguage(Dropdown languageDD)
    {
        string languageSelected = "";
        if (languageDD != null && languageDD.options != null && languageDD.options.Count > languageDD.value)
        {
            languageSelected = languageDD.options[languageDD.value].text;
            DataManager.currentLanguage = languageSelected;
            if (SaveText != null)
            {
                SaveText.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_SAVE_PLAYER, languageSelected);
            }
            if (LoadText != null)
            {
                LoadText.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_LOAD_PLAYER, languageSelected);
            }
            if (Score != null)
            {
                Score.text = DataManager.GetTranslation(DataManager.LOC_KEY_TEXT_SCORE, languageSelected);
            }
            if (MainManu != null)
            {
                MainManu.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_MAIN_MENU, languageSelected);
            }

            Debug.Log("Selected Language: " + languageSelected);
        }
    }


}


