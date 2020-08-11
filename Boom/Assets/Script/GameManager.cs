using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
 
    public BoardManager boardManager;
    public int level = 1;

    public EnemyController emc;
    // Start is called before the first frame update
    void Awake()
    {
        boardManager = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        //doingSetup = true;
        //levelimage = GameObject.Find("levelimage");
        //Leveltext = GameObject.Find("Leveltext").GetComponent<Text>();
        //Leveltext.text = "Level " + level;
        //levelimage.SetActive(true);
        //Invoke("Hidlevelimage", levelStartDelay);
        boardManager.SetUpScene();

    }
    private void OnLevelWasLoaded(int level)
    {
        level++;
        InitGame();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
