using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManu : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject puasemanu;
    public Button SaveButton;
    public Button LoadButton;
    public Text SaveText;
    public Text LoadText;
    public Dropdown languageDropDown;
    public Player player;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (languageDropDown != null)
        {
            languageDropDown.ClearOptions();
            List<string> languageNames = new List<string>();
            languageNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_ENGLISH);
            languageNames.Add(DataManager.LOC_KEY_HEADER_LANGUAGE_FRENCH);
            languageDropDown.AddOptions(languageNames);
            languageDropDown.value = 0;
        }
    }
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

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene1");
        Time.timeScale = 1f;

    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void Save()
    {
        player.save();
    }
    public void Load()
    {
        player.load();
        

    }
    public void SelectLanguage(Dropdown languageDD)
    {
        string languageSelected = "";
        if(languageDD != null && languageDD.options!=null && languageDD.options.Count>languageDD.value)
        {
            languageSelected = languageDD.options[languageDD.value].text;
            DataManager.currentLanguage = languageSelected;
            if(SaveText!=null)
            {
                SaveText.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_SAVE_PLAYER, languageSelected);

            }
            if(LoadText !=null)
            {
                LoadText.text = DataManager.GetTranslation(DataManager.LOC_KEY_BUTTON_LOAD_PLAYER, languageSelected);
            }
        }
    }
}
