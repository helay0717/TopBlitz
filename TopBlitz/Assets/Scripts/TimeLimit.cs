using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public float timeLimit = 10f; // 초 단위의 제한 시간 (예: 10초)
    public TMP_Text timeLimitText; // 제한 시간을 표시할 UI Text 요소

    void Update()
    {
        // 제한 시간을 감소시킵니다.
        timeLimit -= Time.deltaTime;

        // 제한 시간이 0 이하로 떨어지지 않도록 보정합니다.
        timeLimit = Mathf.Max(timeLimit, 0f);

        // UI Text에 제한 시간을 업데이트합니다.
        UpdateTimeLimitText();

        // 제한 시간이 0 이하로 떨어지면 게임 종료 또는 필요한 로직 수행
        if (timeLimit <= 0f)
        {
            // 필요한 로직 수행 (예: 게임 종료)
            EndGame();
        }
    }

    void UpdateTimeLimitText()
    {
        // 제한 시간을 분과 초로 변환하여 UI Text에 표시합니다.
        int minutes = Mathf.FloorToInt(timeLimit / 60f);
        int seconds = Mathf.FloorToInt(timeLimit % 60f);
        timeLimitText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // 게임 종료 로직을 수행합니다.
        Debug.Log("게임 종료!");
        SceneManager.LoadScene("MatchEnd");
    }

}
