using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MatchEnd: MonoBehaviour
{
    public TMP_Text redTeamScoreText; // Red 팀 스코어를 표시할 UI Text 요소
    public TMP_Text blueTeamScoreText; // Blue 팀 스코어를 표시할 UI Text 요소
    public TMP_Text winnerText; // 승자를 표시할 UI Text 요소
    public TMP_Text playerListText; // 플레이어 리스트를 표시할 UI Text 요소

    private Dictionary<string, int> playerScores = new Dictionary<string, int>(); // 플레이어 스코어를 저장할 딕셔너리

    void Start() //GameManager는 임의의 변수. 인게임 결과 (킬스코어 등등..)와 연관지어서 만들어야 함.
    {
        // Red 팀과 Blue 팀의 스코어를 표시

        /* redTeamScoreText.text = "Red Team Score: " + GameManager.redTeamScore.ToString();
        blueTeamScoreText.text = "Blue Team Score: " + GameManager.blueTeamScore.ToString();

        // Red 팀과 Blue 팀 중 스코어가 높은 팀을 결정하여 승자를 표시

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

        // 플레이어 리스트 생성 및 표시
        GeneratePlayerList();
    }

    void GeneratePlayerList()
    {
        // 플레이어 스코어를 딕셔너리에서 가져와 정렬
        List<KeyValuePair<string, int>> sortedPlayers = new List<KeyValuePair<string, int>>(playerScores);
        sortedPlayers.Sort((x, y) => y.Value.CompareTo(x.Value)); // 스코어를 기준으로 내림차순 정렬

        // 플레이어 리스트 텍스트 구성
        playerListText.text = "Player List:\n";
        foreach (KeyValuePair<string, int> player in sortedPlayers)
        {
            playerListText.text += player.Key + ": " + player.Value.ToString() + "\n";
        }
    }

    // 플레이어 스코어를 업데이트하는 함수
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

