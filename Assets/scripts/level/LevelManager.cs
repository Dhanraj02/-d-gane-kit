using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get { return instance; } }

    private static LevelManager instance;
    public string Level1;
    public string[] Levels;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
    public void MarkLevelComplete(string level)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        // int nextSceneIndex = currentScene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        //Debug.Log("next scene is vaild:" + nextScene.IsValid());
        //SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
        int currentSceneIndex = Array.FindIndex(Levels, levels => levels == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level,(int) levelStatus);
        Debug.Log("setting level : " + level + "Status:" + levelStatus);
    }
}
