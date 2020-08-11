using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    public Text LevelText;
    public InputField nameInput;
    public Button nameBtn;
    public Button IncreaseLevel;
    public Dropdown languageDropDown;
    public Text saveButtonText;
    public Text Increase5Level;
    public Button GetCurrency;
    public Text GetCurrencyText;
    public Button Player;
    public Text PlayerText;
    public Button Enemy;
    public Text EnemyText;
    public Text Title;
    public Text Hello;
    public Text Country;
    public Text Level;
    public Button Achoice;
    public Text AchoiceText;
   






    private void Start()
    {
        //if (CurrencyText != null)
        //{
        //    CurrencyText.text = PersistentDataManager.GetCurrency().ToString();
        //}
        if (nameInput != null)
        {
            nameInput.text = PersistentDataManager.GetName();
        }
        if (LevelText != null)
        {
            LevelText.text = PersistentDataManager.GetGameLevel().ToString();

        }
        if (languageDropDown != null)
        {
            languageDropDown.ClearOptions();
            List<string> langNames = new List<string>();
            langNames.Add(Datamanager.LOC_KEY_HEADER_LANGUAGE_ENGLISH);
            langNames.Add(Datamanager.LOC_KEY_HEADER_LANGUAGE_FRENCH);
            langNames.Add(Datamanager.LOC_KEY_HEADER_LANGUAGE_GERMAN);
            langNames.Add(Datamanager.LOC_KEY_HEADER_LANGUAGE_SPANISH);
            languageDropDown.AddOptions(langNames);
            languageDropDown.value = 0;
        }
    }

    public void ChangeName()
    {
        if (nameInput != null)
        {
            PersistentDataManager.UpdatePlayerData(nameInput.text);
        }
    }


    public void InLevel()
    {
        PersistentDataManager.IncreaseGameLevel(5);
        LevelText.text = PersistentDataManager.GetGameLevel().ToString();

    }
    //public void BuyCurrency(int purchaseAmount)
    //{
    //    PersistentDataManager.ChangeCurrency(purchaseAmount);
    //    CurrencyText.text = PersistentDataManager.GetCurrency().ToString();
    //}
    public void SelectLanguage(Dropdown languageDD)
    {
        string languageSelected = "";
        if (languageDD != null && languageDD.options != null && languageDD.options.Count > languageDD.value)
        {
            languageSelected = languageDD.options[languageDD.value].text;
            Datamanager.currentLanguage = languageSelected;
            if (saveButtonText != null)
            {
                saveButtonText.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_SAVE_NAME, languageSelected);
            }
            if (Increase5Level != null)
            {
                Increase5Level.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_INCREASE_LEVEL, languageSelected);
            }
            if (GetCurrencyText != null)
            {
                GetCurrencyText.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_GETCURRENCY, languageSelected);
            }
            if (PlayerText != null)
            {
                PlayerText.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_PLAYER, languageSelected);
            }
            if (EnemyText != null)
            {
                EnemyText.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_ENEMY, languageSelected);
            }
            if (Title != null)
            {
                Title.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_TEXT_TITLE, languageSelected);
            }
            if (Hello != null)
            {
                Hello.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_TEXT_HELLO, languageSelected);
            }
            if (Country != null)
            {
                Country.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_TEXT_COUNTRY, languageSelected);
            }
            if (Level != null)
            {
                Level.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_TEXT_LEVEL, languageSelected);
            }
            if (AchoiceText != null)
            {
                AchoiceText.text = Datamanager.GetTranslation(Datamanager.LOC_KEY_BUTTON_ACHOICE, languageSelected);
            }
            Debug.Log("Selected Language: " + languageSelected);
        }
    }
}
