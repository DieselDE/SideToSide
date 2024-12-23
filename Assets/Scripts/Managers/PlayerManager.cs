using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player player;
    private bool playerCanMove;
    private float playerSpeed;

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
        ChangePlayerSpeed(5f);
    }

    public Player GetPlayer() { return player; }
    public void ChangePlayer(Player newPlayer) {  player = newPlayer; }

    public bool GetPlayerCanMove() { return playerCanMove; }
    public void ChangePlayerCanMove(bool state) { playerCanMove = state; }

    public float GetPlayerSpeed() { return playerSpeed; }
    public void ChangePlayerSpeed(float speed) { playerSpeed = speed; }

    public void SpawnPlayer()
    {
        if(PlayerData == null || PlayerData.PlayerPrefab == null)
        {
            Debug.LogError("PlayerData or PlayerPrefab is not assigned in the Inspector!");
            return;
        }
        if(player != null)
        {
            Debug.LogError("Player already exists!");
            return;
        }

        player = Instantiate(PlayerData.PlayerPrefab, Vector3.zero, Quaternion.identity);
        player.name = PlayerData.name;

        player.SpawnPlayer();

        Debug.Log($"Player '{player.name}' spawned successfully with color '{PlayerData.PlayerColor}'!");
    }
}