﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVlloader 
{
    // Start is called before the first frame update
    public static List<CSVTest> LoadCSVFromFile(string path, string filename)
    {
        List<CSVTest> dataList = new List<CSVTest>();
        string curFilePath = path + Path.DirectorySeparatorChar + filename;
        Debug.Log("Loading file from " + path + Path.DirectorySeparatorChar + filename);
        //FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + filename, FileMode.Open);
        using (var reader = new StreamReader(@curFilePath))
        {
            bool isHeader = true;
            List<string> lines = new List<string>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                lines.Add(line);
                Debug.Log("Line " + lines.Count.ToString() + ": " + line);
                List<string> curData = new List<string>();
                curData.AddRange(values);
                CSVTest curTestData = new CSVTest();

                if (!isHeader)
                {
                    curTestData.Id = int.Parse(curData[0], 0);
                    curTestData.UserName = curData[1];
                    curTestData.Occupation = curData[2];
                    dataList.Add(curTestData);
                }
                else
                {
                    isHeader = false;
                }

                string outputStr = "Values: ";
                for (int i = 0; i < dataList.Count; i++)
                {
                    outputStr += dataList[i].Id + ", " + dataList[i].UserName + ", " + dataList[i].Occupation + " - ";
                }
                Debug.Log(outputStr);
            }

        }
        Debug.Log("Data created: " + dataList.Count.ToString());
        return dataList;
    }
}
