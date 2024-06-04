using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync("PlayerMovementScene"); //Scene 이름을 바꿔야함; 맵을 불러오는 화면으로
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;
            if (op.progress >= 0.9f)
            {
                op.allowSceneActivation = true;
            }
        }
    }
}