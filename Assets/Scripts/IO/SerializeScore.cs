using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class SerializeScore : MonoBehaviour
{
    const string FILENAME = "data.json";

    int score = 0;

    //// Use this for initialization
    //void Start()
    //{
    //    Debug.LogFormat("dataPath: {0}", Application.dataPath);
    //    Debug.LogFormat("persistentDataPath: {0}", Application.persistentDataPath);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            score++;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SaveScore();
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            LoadScore();
        }
    }

    private void LoadScore()
    {
        // get path
        string path = Application.persistentDataPath;

        // combine with filename
        string filepath = Path.Combine(path, FILENAME);

        // check if file exists
        if (!File.Exists(filepath))
        {
            Debug.LogWarningFormat("File at path {0} does not exist.", filepath);
            return;
        }

        // read JSON string from file
        string jsonString = File.ReadAllText(filepath);

        Debug.LogFormat("JSON string: {0}", jsonString);

        // create SaveData instance from JSON string
        SaveData data = JsonUtility.FromJson<SaveData>(jsonString);

        this.score = data.scoreEntries[0].score;
    }

    private void SaveScore()
    {
        // get path
        string path = Application.persistentDataPath;

        // combine with filename
        string filepath = Path.Combine(path, FILENAME);

        Debug.LogFormat("filepath: {0}", filepath);

        // create save data
        SaveData data = new SaveData();
        data.scoreEntries = new List<DataEntry>();
        data.scoreEntries.Add(new DataEntry(System.Environment.UserName, this.score));

        // generate JSON string
        string jsonString = JsonUtility.ToJson(data, true);

        Debug.LogFormat("JSON: {0}", jsonString);

        // save JSON string to file
        File.WriteAllText(filepath, jsonString);

        Debug.Log("Save successful!");
    }
}

[System.Serializable]
public class SaveData
{
    public List<DataEntry> scoreEntries;
}

[System.Serializable]
public class DataEntry
{
    public string name;
    public int score;

    public DataEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
