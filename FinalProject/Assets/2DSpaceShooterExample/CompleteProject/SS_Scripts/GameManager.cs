using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SharedValues_Script value;
    public Player_Script curplayer;
    public GameController_Script curgamecontroller;


    public void UpdatePlayerData()
    {
        PersistentManager.UpdatePlayerData(curplayer.health, value.GetScore());

    }

    public void LoadPlayerData()
    {
        PersistentManager.LoadData();
        value.scoreText.text = PersistentManager.curPlayer.Score.ToString();
        value.SetScore(PersistentManager.curPlayer.Score);
        curplayer.health = PersistentManager.curPlayer.health;
        curplayer.healthbar.value = curplayer.health;
        curplayer.healthtext.text = curplayer.health.ToString();
    }

}
