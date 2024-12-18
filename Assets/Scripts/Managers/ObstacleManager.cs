using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ObstacleManager : MonoBehaviour
{
    private bool obstacleCanSpawn;
    private float obstacleSpeed;
    private float obstacleSpawnHeight;
    private float obstacleDeleteHeight;

    public ScriptableObstacle ObstacleData;
    public static ObstacleManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartUp(bool canSpawn, float speed, float spawnHeight, float deleteHeight)
    {
        ChangeObstacleSpawnState(canSpawn);
        ChangeObstacleSpeed(speed);
        ChangeObstacleSpawnHeight(spawnHeight);
        ChangeObstacleDeleteHeight(deleteHeight);

        Debug.Log("ObstacleManager successfully initialized.");
    }

    public bool GetObstacleSpawnState() { return obstacleCanSpawn; }
    public void ChangeObstacleSpawnState(bool newState) { obstacleCanSpawn = newState; }

    public float GetObstacleSpeed() { return obstacleSpeed; }
    public void ChangeObstacleSpeed(float newSpeed) { obstacleSpeed = newSpeed; }

    public float GetObstacleSpawnHeight() { return obstacleSpawnHeight; }
    public void ChangeObstacleSpawnHeight(float newHeight) { obstacleSpawnHeight = newHeight; }

    public float GetObstacleDeleteHeight() { return obstacleDeleteHeight; }
    public void ChangeObstacleDeleteHeight(float newHeight) { obstacleDeleteHeight = newHeight; }

    public void SpawnObstacle()
    {
        if (ObstacleData == null || ObstacleData.ObstaclePrefab == null)
        {
            Debug.LogError("ObstacleData or ObstaclePrefab is not assigned!");
            return;
        }

        Vector3 spawnPosition = new Vector2(Random.Range(-5f,5f), obstacleSpawnHeight);
        Obstacles newObstacle = Instantiate(ObstacleData.ObstaclePrefab, spawnPosition, Quaternion.identity);
        newObstacle.InitializeObstacle(ObstacleData);
    }
}
