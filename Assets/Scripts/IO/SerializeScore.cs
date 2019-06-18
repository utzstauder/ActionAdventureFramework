using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class SerializeScore : MonoBehaviour
{
    const string FILENAME = "data.json";

    int score = 0;

    // Use this for initialization
    void Start()
    {
        //Debug.LogFormat("dataPath: {0}", Application.dataPath);
        //Debug.LogFormat("persistentDataPath: {0}", Application.persistentDataPath);
        LoadScore();
    }

    void OnApplicationQuit()
    {
        SaveScore();
    }

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

        //var serializer = new XmlSerializer(typeof(SaveData));
        //using (var stream = new FileStream(filepath, FileMode.Create))
        //{
        //    serializer.Serialize(stream, data);
        //}
    }
}

[System.Serializable]
[XmlRoot]
public class SaveData
{
    [XmlArray, XmlArrayItem("DataEntry")]
    public List<DataEntry> scoreEntries;
}

[System.Serializable]
[XmlRoot]
public class DataEntry
{
    [XmlElement]
    public string name;
    [XmlElement]
    public int score;

    public DataEntry()
    {
        name = "";
        score = 0;
    }

    public DataEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
