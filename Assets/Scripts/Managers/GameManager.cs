using System.Runtime.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        PlayerManager.Instance.ChangePlayerState(false);
        ObstacleManager.Instance.ChangeObstacleSpawnState(true);

        PlayerManager.Instance.SpawnPlayer();
        WallManager.Instance.SpawnWalls();
        UpdateGameState(GameState.PlayerMove);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(State)
        {
            case GameState.PlayerMove:
                PlayerManager.Instance?.ChangePlayerState(true);
                break;
            case GameState.End:
                PlayerManager.Instance?.ChangePlayerState(false);
                break;
            default:
                Debug.LogError($"Problems with GameState {State}");
                break;
        }
    }
}

public enum GameState
{
    PlayerMove,
    End,
    Test
}
