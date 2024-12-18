using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private Vector2 direction;

    void Start()
    {
        direction = Vector2.down;
    }

    void Update()
    {
        MoveObstacle(direction);
        CheckDeleteHeight();
    }

    public void InitializeObstacle(ScriptableObstacle data)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = GetColorFromObstacleColor(data.ObstacleColor);
        }
    }

    private Color GetColorFromObstacleColor(ObstacleColor color)
    {
        switch (color)
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

    public void MoveObstacle(Vector2 direction)
    {
        float speed = ObstacleManager.Instance.GetObstacleSpeed();
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void CheckDeleteHeight()
    {
        float deleteHeight = ObstacleManager.Instance.GetObstacleDeleteHeight();

        if (transform.position.y <= deleteHeight)
        {
            Destroy(gameObject);
        }
    }
}
