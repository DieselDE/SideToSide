using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour
{
    private bool obstacleCanSpawn;
    private float obstacleSpeed;
    private float obstacleSpawnHeight;
    private float obstacleDeleteHeight;

    private float spawnInterval = 1f;
    private float minimumSpawnInterval = 0.2f;
    private float spawnIntervalDecrement = 0.01f;
    private Coroutine spawnCoroutine;

    public ScriptableObstacle ObstacleData;
    public static ObstacleManager Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private IEnumerator SpawnObstaclesRoutine()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);

            if(spawnInterval > minimumSpawnInterval)
            {
                spawnInterval -= spawnIntervalDecrement;
            }
        }
    }

    public void StartUp(bool canSpawn, float speed, float spawnHeight, float deleteHeight)
    {
        ChangeObstacleSpawnState(canSpawn);
        ChangeObstacleSpeed(speed);
        ChangeObstacleSpawnHeight(spawnHeight);
        ChangeObstacleDeleteHeight(deleteHeight);

        if(obstacleCanSpawn && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnObstaclesRoutine());
        }

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
        if(ObstacleData == null || ObstacleData.ObstaclePrefab == null)
        {
            Debug.LogError("ObstacleData or ObstaclePrefab is not assigned!");
            return;
        }
        if(!obstacleCanSpawn)
        {
            return;
        }

        Vector3 spawnPosition = new Vector2(GetRandomSpawn(-5f, 5f), obstacleSpawnHeight);
        Obstacles newObstacle = Instantiate(ObstacleData.ObstaclePrefab, spawnPosition, Quaternion.identity);
        newObstacle.InitializeObstacle();
        Counter.Instance.AddToCounter();
    }

    public float GetRandomSpawn(float start, float end)
    {
        float randomSpawn = Random.Range(start, end);
        randomSpawn = Mathf.Round(randomSpawn);

        return randomSpawn;
    }

    public void StopSpawning()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}
