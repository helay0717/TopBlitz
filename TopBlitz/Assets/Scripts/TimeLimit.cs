using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public float timeLimit = 10f; // �� ������ ���� �ð� (��: 10��)
    public TMP_Text timeLimitText; // ���� �ð��� ǥ���� UI Text ���

    void Update()
    {
        // ���� �ð��� ���ҽ�ŵ�ϴ�.
        timeLimit -= Time.deltaTime;

        // ���� �ð��� 0 ���Ϸ� �������� �ʵ��� �����մϴ�.
        timeLimit = Mathf.Max(timeLimit, 0f);

        // UI Text�� ���� �ð��� ������Ʈ�մϴ�.
        UpdateTimeLimitText();

        // ���� �ð��� 0 ���Ϸ� �������� ���� ���� �Ǵ� �ʿ��� ���� ����
        if (timeLimit <= 0f)
        {
            // �ʿ��� ���� ���� (��: ���� ����)
            EndGame();
        }
    }

    void UpdateTimeLimitText()
    {
        // ���� �ð��� �а� �ʷ� ��ȯ�Ͽ� UI Text�� ǥ���մϴ�.
        int minutes = Mathf.FloorToInt(timeLimit / 60f);
        int seconds = Mathf.FloorToInt(timeLimit % 60f);
        timeLimitText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // ���� ���� ������ �����մϴ�.
        Debug.Log("���� ����!");
        SceneManager.LoadScene("MatchEnd");
    }

}
