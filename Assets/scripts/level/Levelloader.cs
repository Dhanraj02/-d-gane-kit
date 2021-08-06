using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class Levelloader : MonoBehaviour
{
    public string LevelName;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("can't play this level till you unlock it");
                break;
            case LevelStatus.Unlocked:
                break;
            case LevelStatus.Completed:
                break;
        }
        SceneManager.LoadScene(LevelName);
    }
}
