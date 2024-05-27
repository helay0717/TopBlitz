using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //뒤로가기 함수
    public void onClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickPlayerNum()
    {
        SceneManager.LoadScene("PlayerNum");
    }

    public void onClickMatchStart()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
