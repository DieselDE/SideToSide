using UnityEngine;

public class WallManager : MonoBehaviour
{
    public static WallManager Instance;
    public GameObject WallPrefab;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SpawnWalls()
    {
        if(WallPrefab == null)
        {
            Debug.LogError("WallPrefab not assigned in the Inspector!");
            return;
        }

        Vector3 leftWallPosition = new Vector3(-10, 0, 0);
        Vector3 rightWallPosition = new Vector3(10, 0, 0);

        GameObject leftWall = Instantiate(WallPrefab, leftWallPosition, Quaternion.identity);
        leftWall.name = "LeftWall";

        GameObject rightWall = Instantiate(WallPrefab, rightWallPosition, Quaternion.identity);
        rightWall.name = "RightWall";

        Debug.Log("Walls spawned successfully!");
    }
}
