using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //�ڷΰ��� �Լ�
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
