using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{   
    //�ڷΰ��� �Լ�
    public void onClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

}