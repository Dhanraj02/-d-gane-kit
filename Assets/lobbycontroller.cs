using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lobbycontroller : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
