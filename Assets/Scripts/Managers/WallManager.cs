using UnityEngine;

public class WallManager : MonoBehaviour
{
    public static WallManager Instance;
    public GameObject WallPrefab;
    public GameObject LeftWall;
    public GameObject RightWall;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartUp()
    {
        SpawnWalls();
    }

    public void SpawnWalls()
    {
        if(WallPrefab == null)
        {
            Debug.LogError("WallPrefab not assigned in the Inspector!");
            return;
        }
        if(LeftWall != null || RightWall != null)
        {
            Debug.LogError("Walls already exist!");
            return;
        }

        Vector3 leftWallPosition = new Vector3(-6f, 0, 0);
        Vector3 rightWallPosition = new Vector3(6f, 0, 0);

        LeftWall = Instantiate(WallPrefab, leftWallPosition, Quaternion.identity);
        LeftWall.name = "LeftWall";

        RightWall = Instantiate(WallPrefab, rightWallPosition, Quaternion.identity);
        RightWall.name = "RightWall";

        Debug.Log("Walls spawned successfully!");
    }
}
