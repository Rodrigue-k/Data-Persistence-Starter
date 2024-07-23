using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameT;
    public Text bestPlayer;

    void Start()
    {
        DataManager.Instance.Load();

        if (DataManager.Instance.bestScorePlayerName != null)
        {
            bestPlayer.text = $"The best of this game is: {DataManager.Instance.bestScorePlayerName} : {DataManager.Instance.bestScore}";
        }
        else
        {
            bestPlayer.text = "No best score yet.";
        }
    }

    public void StartNew()
    {
        DataManager.Instance.playerNewName = nameT.text;

        DataManager.Instance.Save();
        SceneManager.LoadScene(1);

        string playerName = nameT.text;
        Debug.Log("player name is :" + playerName);
    }

    public void Exit()
    {
        DataManager.Instance.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

}
