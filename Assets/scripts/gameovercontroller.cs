using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameovercontroller : MonoBehaviour
{
    public Button buttonRestart;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(Reloadlevel);
    }
    public void PlayerDied()
    {  
        gameObject.SetActive(true);
    }
    private void Reloadlevel()
    {
        Debug.Log("Reloading scene...");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}