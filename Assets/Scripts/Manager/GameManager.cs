using Data;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<PlayerStat, Color> onDataReceived;
    private bool isPlayerLive;
    public int stageNum;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerData(PlayerStat playerStat, Color color)
    {
        onDataReceived?.Invoke(playerStat, color);
    }

    public bool IsPlayerLive()
    {
        return isPlayerLive;
    }

    public void SetPlayerLive(bool live)
    {
        isPlayerLive = live;
    }
    
}