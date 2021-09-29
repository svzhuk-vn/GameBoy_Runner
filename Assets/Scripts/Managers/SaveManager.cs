using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class SaveManager : MonoBehaviour
{
    [Header("Game data")]
    [Tooltip("Game data stcructure.")]
    [SerializeField] private GameData gameData;

    [Header("Settings")]
    [Tooltip("Save file name.")]
    [SerializeField] private string saveFileName;

    [Tooltip("Save directory name.")]
    [SerializeField] private string saveDirectoryName;

    [Tooltip("Path to save directory.")]
    [SerializeField] private string saveDirectoryPath;

    [Tooltip("Path to save file.")]
    [SerializeField] private string saveFilePath;
    [SerializeField] private UnityEvent<GameData> dalaLoaded;
    [SerializeField] private UnityEvent<GameData> dataSaved;

    private void SaveDataToFile()
    {
        string json = JsonUtility.ToJson(this.gameData);
        File.WriteAllText(this.saveFilePath, json);
        this.dataSaved?.Invoke(this.gameData);    
    }

    private void Awake()
    {
#if UNITY_ANDROID
        this.saveDirectoryPath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName);
        this.saveFilePath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName, this.saveFileName);
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
        this.saveDirectoryPath = Path.Combine(Application.dataPath, this.saveDirectoryName);
        this.saveFilePath = Path.Combine(Application.dataPath, this.saveDirectoryName, this.saveFileName);
#endif
    
    if (Directory.Exists(this.saveDirectoryPath) == false)
        {
            Debug.Log("Save directory created");
            Directory.CreateDirectory(this.saveDirectoryPath);
    
        }
        if (File.Exists(this.saveFilePath))
        {
            string json = File.ReadAllText(this.saveFilePath);
            GameData gameDataFromJson = JsonUtility.FromJson<GameData>(json);
            this.gameData = gameDataFromJson;
            Debug.Log("Data loaded created");
            this.dalaLoaded?.Invoke(this.gameData);
        }
        }

        private void OnApplicationPause(bool pause)
    { 
    
        
    
#if UNITY_ANDROID
    SaveDataToFile();
        Debug.Log("Data saved to file");
#endif
        }

        private void OnApplicationQuit()
    {
            SaveDataToFile();
    }

        public void OnHigtScoreChanged(int highScore) => this.gameData.hightScoreCount = highScore;
}


