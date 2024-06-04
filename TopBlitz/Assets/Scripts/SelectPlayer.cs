using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int characterID; // 해당 버튼에 연결된 캐릭터의 ID

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SelectCharacter);
    }

    void SelectCharacter()
    {
        // 게임 매니저에 선택된 캐릭터의 ID를 전달하여 캐릭터를 변경합니다.
        GameManager.instance.ChangeCharacter(characterID);
    }
}