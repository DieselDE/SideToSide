using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player player;
    private bool playerCanMove;

    public static PlayerManager Instance;
    public ScriptablePlayer PlayerData;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartUp()
    {
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        if(PlayerData == null || PlayerData.PlayerPrefab == null)
        {
            Debug.LogError("PlayerData or PlayerPrefab is not assigned in the Inspector!");
            return;
        }

        player = Instantiate(PlayerData.PlayerPrefab, Vector3.zero, Quaternion.identity);
        player.name = PlayerData.name;

        player.SpawnPlayer(PlayerData);

        Debug.Log($"Player '{player.name}' spawned successfully with color '{PlayerData.PlayerColor}'!");
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void ChangePlayerState(bool state)
    {
        playerCanMove = state;
    }

    public bool PlayerSpawnState()
    {
        return playerCanMove;
    }
}