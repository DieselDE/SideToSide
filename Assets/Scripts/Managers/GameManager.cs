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
        PlayerManager.Instance.StartUp();
        WallManager.Instance.StartUp();
        ObstacleManager.Instance.StartUp(true, 2f, 5f, -5f);
        Counter.Instance.StartUp();

        UpdateGameState(GameState.PlayerMove);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(State)
        {
            case GameState.PlayerMove:
                PlayerManager.Instance.ChangePlayerMoveState(true);
                ObstacleManager.Instance.ChangeObstacleSpawnState(true);
                break;
            case GameState.End:
                PlayerManager.Instance.ChangePlayerMoveState(false);
                ObstacleManager.Instance.ChangeObstacleSpawnState(false);
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
