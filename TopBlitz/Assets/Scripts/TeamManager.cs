using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 싱글톤 인스턴스를 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 있으면 삭제
        }
    }

    public Color GetTeamColor(Team team)
    {
        // 팀 색상을 반환하는 로직을 여기에 추가
        if (team == Team.Red)
        {
            return Color.red;
        }
        else if (team == Team.Blue)
        {
            return Color.blue;
        }
        return Color.white;
    }
}