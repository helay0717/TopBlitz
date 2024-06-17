using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LobbyUI : MonoBehaviourPunCallbacks
{
    private bool isConnecting = false;

    public void On1vs1ButtonClicked()
    {
        PlayerPrefs.SetInt("GameMode", 2);
        StartMatchmaking();
    }

    public void On3vs3ButtonClicked()
    {
        PlayerPrefs.SetInt("GameMode", 6);
        StartMatchmaking();
    }

    public void On5vs5ButtonClicked()
    {
        PlayerPrefs.SetInt("GameMode", 10);
        StartMatchmaking();
    }

    private void StartMatchmaking()
    {
        isConnecting = true;
        if (PhotonNetwork.IsConnectedAndReady)
        {
            JoinOrCreateRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server.");
        if (isConnecting)
        {
            JoinOrCreateRoom();
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby.");
        if (isConnecting)
        {
            JoinOrCreateRoom();
        }
    }

    private void JoinOrCreateRoom()
    {
        int gameMode = PlayerPrefs.GetInt("GameMode", 2);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)gameMode;
        PhotonNetwork.JoinRandomOrCreateRoom(null, (byte)gameMode, MatchmakingMode.FillRoom, null, null, null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room. Current player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            AssignTeams(); // 매칭 완료 후 팀 할당
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player entered the room. Current player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            AssignTeams(); // 매칭 완료 후 팀 할당
        }
    }

    private void AssignTeams()
    {
        Player[] players = PhotonNetwork.PlayerList;
        List<Team> teams = new List<Team> { Team.Red, Team.Blue };
        int playersPerTeam = players.Length / 2;
        int playerIndex = 0;

        // 블루팀과 레드팀으로 플레이어를 반반씩 나눔
        foreach (Player player in players)
        {
            Team assignedTeam = teams[playerIndex < playersPerTeam ? 0 : 1]; // 0번 인덱스는 블루팀, 1번 인덱스는 레드팀
            player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "PlayerTeam", assignedTeam.ToString() } });
            playerIndex++;
        }

        PhotonNetwork.LoadLevel("SelectGun"); // 팀 할당 후 SelectGun 씬으로 이동
    }
}