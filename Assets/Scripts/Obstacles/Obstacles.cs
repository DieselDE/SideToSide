using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private ScriptableObstacle scriptableObstacle;
    private Vector2 direction;
    private float obstacleSpeed;

    void Start()
    {
        direction = Vector2.down;
    }

    private void Update()
    {
        MoveObstacle(direction);
    }

    public void SpawnObstacle(ScriptableObstacle data)
    {
        scriptableObstacle = data;
        obstacleSpeed = 0.5f; // change this

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = GetColorFromObstacleColor(scriptableObstacle.ObstacleColor);
        }
    }
    private Color GetColorFromObstacleColor(ObstacleColor ObstacleColor)
    {
        switch (ObstacleColor)
        {
            case ObstacleColor.Red: return Color.red;
            case ObstacleColor.Orange: return new Color(1f, 0.5f, 0f);
            case ObstacleColor.Pink: return new Color(1f, 0.75f, 0.8f);
            case ObstacleColor.Yellow: return Color.yellow;
            case ObstacleColor.Lime: return new Color(0.75f, 1f, 0.25f);
            case ObstacleColor.Green: return Color.green;
            case ObstacleColor.LightBlue: return new Color(0.68f, 0.85f, 0.9f);
            case ObstacleColor.Cyan: return Color.cyan;
            case ObstacleColor.Blue: return Color.blue;
            case ObstacleColor.Magenta: return Color.magenta;
            case ObstacleColor.Purple: return new Color(0.5f, 0f, 0.5f);
            case ObstacleColor.Brown: return new Color(0.59f, 0.29f, 0f);
            case ObstacleColor.Gray: return Color.gray;
            case ObstacleColor.LightGray: return new Color(0.83f, 0.83f, 0.83f);
            case ObstacleColor.Black: return Color.black;
            default: return Color.white;
        }
    }

    public void SetObstacleSpeed(float newSpeed)
    {
        obstacleSpeed = newSpeed;
    }

    public void MoveObstacle(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction * obstacleSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
