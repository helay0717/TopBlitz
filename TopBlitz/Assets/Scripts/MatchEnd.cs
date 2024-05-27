using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MatchEnd: MonoBehaviour
{
    public TMP_Text redTeamScoreText; // Red �� ���ھ ǥ���� UI Text ���
    public TMP_Text blueTeamScoreText; // Blue �� ���ھ ǥ���� UI Text ���
    public TMP_Text winnerText; // ���ڸ� ǥ���� UI Text ���
    public TMP_Text playerListText; // �÷��̾� ����Ʈ�� ǥ���� UI Text ���

    private Dictionary<string, int> playerScores = new Dictionary<string, int>(); // �÷��̾� ���ھ ������ ��ųʸ�

    void Start() //GameManager�� ������ ����. �ΰ��� ��� (ų���ھ� ���..)�� ������� ������ ��.
    {
        // Red ���� Blue ���� ���ھ ǥ��

        /* redTeamScoreText.text = "Red Team Score: " + GameManager.redTeamScore.ToString();
        blueTeamScoreText.text = "Blue Team Score: " + GameManager.blueTeamScore.ToString();

        // Red ���� Blue �� �� ���ھ ���� ���� �����Ͽ� ���ڸ� ǥ��

        if (GameManager.redTeamScore > GameManager.blueTeamScore)
        {
            winnerText.text = "Red Team Wins!";
        }
        else if (GameManager.redTeamScore < GameManager.blueTeamScore)
        {
            winnerText.text = "Blue Team Wins!";
        }
        else
        {
            winnerText.text = "It's a Tie!";
        } */

        // �÷��̾� ����Ʈ ���� �� ǥ��
        GeneratePlayerList();
    }

    void GeneratePlayerList()
    {
        // �÷��̾� ���ھ ��ųʸ����� ������ ����
        List<KeyValuePair<string, int>> sortedPlayers = new List<KeyValuePair<string, int>>(playerScores);
        sortedPlayers.Sort((x, y) => y.Value.CompareTo(x.Value)); // ���ھ �������� �������� ����

        // �÷��̾� ����Ʈ �ؽ�Ʈ ����
        playerListText.text = "Player List:\n";
        foreach (KeyValuePair<string, int> player in sortedPlayers)
        {
            playerListText.text += player.Key + ": " + player.Value.ToString() + "\n";
        }
    }

    // �÷��̾� ���ھ ������Ʈ�ϴ� �Լ�
    public void UpdatePlayerScore(string playerName, int score)
    {
        if (!playerScores.ContainsKey(playerName))
        {
            playerScores.Add(playerName, score);
        }
        else
        {
            playerScores[playerName] += score;
        }
    }

    public void onClickMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

