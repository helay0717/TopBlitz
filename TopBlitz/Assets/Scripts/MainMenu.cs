using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void onClickGameStart()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void onClickSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void onClickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

