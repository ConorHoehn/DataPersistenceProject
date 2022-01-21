using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    

    public static MainManager Instance { get; private set; }
    [SerializeField] private bool resetScore = false;

    public HighScoreData highScore;

    [System.Serializable]
    public class HighScoreData {
        public int points;
        public string playerName; 
    }

    private void Awake()
    {
         if (!Instance)
        {
            Instance = this;
            LoadSaveDataFromFile();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadSaveDataFromFile()
    {
        HighScoreData sd = null;
        if (System.IO.File.Exists(SavePath()) && !resetScore) {
            string jsonData = System.IO.File.ReadAllText(SavePath());
            sd = JsonUtility.FromJson<HighScoreData>(jsonData);
        }
        else
        {
            sd = new HighScoreData
            {
                playerName = "Conor",
                points = 0
            };
        }
        highScore = sd;

    }

    private string SavePath()
    {
        return Application.persistentDataPath + System.IO.Path.DirectorySeparatorChar + "savedata.json";
    }

    public void SaveHighScore()
    {
        string jsonData = JsonUtility.ToJson(highScore);
        System.IO.File.WriteAllText(SavePath(), jsonData);
    }

    internal bool TrySetHighScore(int newPoints)
    {
        if (highScore != null && newPoints > highScore.points)
        {
            highScore.points = newPoints;
            return true;
        }
        return false;
    }
}
