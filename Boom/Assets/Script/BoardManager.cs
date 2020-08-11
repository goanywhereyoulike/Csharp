using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    [Serializable]
    public class Count
    {
        public int minnum;
        public int maxnum;

        public Count(int min, int max)
        {
            minnum = min;
            maxnum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount ;
    public Count EnemyCount ;
    public GameObject[] walltiles;
    public GameObject[] enemytiles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    // Start is called before the first frame update

    void Initialiselist()
    {
        gridPositions.Clear();
        for(int x=-4;x<columns-1;x++)
         {
            for (int y = -3; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));

            }

        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x =1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                GameObject toInstantiate = walltiles[Random.Range(0, walltiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }

        }

    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomposition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomposition;

    }

    void LayoutObject(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 1; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);

        }


    }

    public void SetUpScene()
    {
        Initialiselist();
        LayoutObject(walltiles, wallCount.minnum, wallCount.maxnum);

    }
    void Start()
    {
        loadLevelData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadLevelData()
    {
        if (File.Exists(Application.dataPath + "/LevelData.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/LevelData.txt");
            LevelData saveobj = JsonUtility.FromJson<LevelData>(saveString);
            wallCount = new Count(saveobj.Wallmin, saveobj.WallMax);
            EnemyCount = new Count(saveobj.EnemyMin, saveobj.EnemyMax);

}
        else
        {
            Debug.Log("Load Failed");
        }

    }
}

public class LevelData
{
    public int EnemyMax;
    public int EnemyMin;
    public int WallMax;
    public int Wallmin;
}