using System.Runtime.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (State)
        {
            case GameState.Menu:
                ButtonManager.Instance.StartUp();
                break;
            case GameState.Game:
                PlayerManager.Instance.StartUp();
                WallManager.Instance.StartUp();
                ObstacleManager.Instance.StartUp(true, 2f, 5f, -5f);
                CounterManager.Instance.StartUp();

                PlayerManager.Instance.ChangePlayerCanMove(true);
                ObstacleManager.Instance.ChangeObstacleSpawnState(true);
                break;
            case GameState.Defeat:
                PlayerManager.Instance.ChangePlayerCanMove(false);
                ObstacleManager.Instance.ChangeObstacleSpawnState(false);
                ObstacleManager.Instance.StopSpawning();

                MenuManager.Instance.StartUp();
                CounterManager.Instance.DeleteCounter();
                break;
            default:
                Debug.LogError($"Problems with GameState {State}");
                break;
        }
    }
}

public enum GameState
{
    Menu,
    Game,
    Defeat,
    Test
}