using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Photon 서버에 연결
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRoom(string mode)
    {
        RoomOptions roomOptions = new RoomOptions();
        switch (mode)
        {
            case "1vs1":
                roomOptions.MaxPlayers = 2;
                break;
            case "3vs3":
                roomOptions.MaxPlayers = 6;
                break;
            case "5vs5":
                roomOptions.MaxPlayers = 10;
                break;
        }
        PhotonNetwork.JoinRandomOrCreateRoom(null, (byte)roomOptions.MaxPlayers, MatchmakingMode.FillRoom, null, null, null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("InGame");
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to join room: " + message);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning("Disconnected from Photon: " + cause.ToString());
    }
}