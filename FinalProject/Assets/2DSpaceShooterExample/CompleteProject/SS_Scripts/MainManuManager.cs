using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManuManager : MonoBehaviour
{
    public Dropdown languageDropDown;
    public Text Score;
    public Text ScoreNum;
    public Text Play;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum.text = "";
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
        ScoreNum.text = PersistentManager.curPlayer.Score.ToString();
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;

    }

    public void SelectLanguage(Dropdown languageDD)
    {
        string languageSelected = "";
        if (languageDD != null && languageDD.options != null && languageDD.options.Count > languageDD.value)
        {
            languageSelected = languageDD.options[languageDD.value].text;
            DataManager.currentLanguage = languageSelected;

            if (Score != null)
            {
                Debug.Log("Socre text changed");
                //Score.text = "But";
                Score.text = DataManager.GetTranslation(DataManager.LOC_KEY_TEXT_SCORE, languageSelected);
               // Debug.Log(Score.text);
            }
            if (Play != null)
            {
                Play.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_PLAY, languageSelected);
            }

            Debug.Log("Selected Language: " + languageSelected);
        }
    }
}
