using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public void RMenu()
    {
        DataManager.Instance.Save();
        SceneManager.LoadScene(0);
    }
}
