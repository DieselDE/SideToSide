using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameState _state;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        updateGameState(GameState.PlayerMove);
    }

    public void updateGameState(GameState newState)
    {
        _state = newState;

        switch(_state)
        {
            case GameState.PlayerMove:
                PlayerManager._instance.playerEnd(true);
                break;
            case GameState.End:
                PlayerManager._instance.playerEnd(false);
                break;
            default:
                Debug.LogError("Problems with GameState {_state}");
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
