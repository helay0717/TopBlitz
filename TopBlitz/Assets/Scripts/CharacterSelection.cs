//using Photon.Pun;
//using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour/*PunCallbacks*/
{
    private int selectedCharacterID;
    //private bool allPlayersSelected = false;

    public void SelectCharacter(int characterID)
    {
        selectedCharacterID = characterID;

        // 선택된 캐릭터 ID를 PlayerPrefs에 저장
        PlayerPrefs.SetInt("SelectedCharacterID", characterID);

        SceneManager.LoadScene("PlayerMovementScene");

        //// 모든 플레이어가 캐릭터를 선택했는지 확인하기 위해 네트워크 상에 선택 정보 전달
        //PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "SelectedCharacterID", characterID } });
    }

    //public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    //{
    //    if (changedProps.ContainsKey("SelectedCharacterID"))
    //    {
    //        모든 플레이어가 선택을 완료했는지 확인
    //        bool allSelected = true;
    //        foreach (Player player in PhotonNetwork.PlayerList)
    //        {
    //            if (!player.CustomProperties.ContainsKey("SelectedCharacterID"))
    //            {
    //                allSelected = false;
    //                break;
    //            }
    //        }

    //        if (allSelected && !allPlayersSelected)
    //        {
    //            allPlayersSelected = true;
    //            모든 플레이어가 선택을 완료했을 때 씬 전환
    //            PhotonNetwork.LoadLevel("PlayerMovementScene");
    //        }
    //    }
    //}
}