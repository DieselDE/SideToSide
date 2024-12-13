using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Obstacles obstacle;
    private bool obstacleCanSpawn;
    private float obstacleSpeed;
    private Vector3 obstacleSpawn;
    private float obstacleDeleteHeight;

    public ScriptableObstacle ObstacleData;
    public static ObstacleManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SpawnObstacle()
    {
        if(!obstacleCanSpawn)
        {
            Debug.Log("Obstacle cant spawn");
            return;
        }
        if(ObstacleData == null || ObstacleData.ObstaclePrefab == null)
        {
            Debug.LogError("ObstacleData or ObstaclePrefab is not assigned in the Inspector!");
            return;
        }

        obstacle = Instantiate(ObstacleData.ObstaclePrefab, Vector3.zero, Quaternion.identity);
        obstacle.name = ObstacleData.name;

        obstacle.SpawnObstacle(ObstacleData);

        Debug.Log($"Obstacle '{obstacle.name}' spawned successfully with color '{ObstacleData.ObstacleColor}' and form '{ObstacleData.ObstacleForm}'");
    }

    public Obstacles GetObstacle()
    {
        return obstacle;
    }

    public void ChangeObstacleSpawnState(bool state)
    {
        obstacleCanSpawn = state;
    }

    public bool ObstacleSpawnState()
    {
        return obstacleCanSpawn;
    }
}
