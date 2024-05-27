using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{   
    //뒤로가기 함수
    public void onClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

}