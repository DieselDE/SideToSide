using UnityEngine;

public class Player : MonoBehaviour
{
    private ScriptablePlayer scriptablePlayer;
    private Vector2 direction;
    private float playerSpeed;

    public void SpawnPlayer(ScriptablePlayer data)
    {
        scriptablePlayer = data;
        playerSpeed = 100f; // change this

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.color = GetColorFromPlayerColor(scriptablePlayer.PlayerColor);
        }
    }

    private Color GetColorFromPlayerColor(PlayerColor playerColor)
    {
        switch(playerColor)
        {
            case PlayerColor.Red: return Color.red;
            case PlayerColor.Orange: return new Color(1f, 0.5f, 0f);
            case PlayerColor.Pink: return new Color(1f, 0.75f, 0.8f);
            case PlayerColor.Yellow: return Color.yellow;
            case PlayerColor.Lime: return new Color(0.75f, 1f, 0.25f);
            case PlayerColor.Green: return Color.green;
            case PlayerColor.LightBlue: return new Color(0.68f, 0.85f, 0.9f);
            case PlayerColor.Cyan: return Color.cyan;
            case PlayerColor.Blue: return Color.blue;
            case PlayerColor.Magenta: return Color.magenta;
            case PlayerColor.Purple: return new Color(0.5f, 0f, 0.5f);
            case PlayerColor.Brown: return new Color(0.59f, 0.29f, 0f);
            case PlayerColor.Gray: return Color.gray;
            case PlayerColor.LightGray: return new Color(0.83f, 0.83f, 0.83f);
            case PlayerColor.Black: return Color.black;
            default: return Color.white;
        }
    }

    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameManager.Instance.State == GameState.PlayerMove)
            {
                GameManager.Instance.UpdateGameState(GameState.End);
            }
            else if(GameManager.Instance.State == GameState.End)
            {
                GameManager.Instance.UpdateGameState(GameState.PlayerMove);
            }
        }

        if(PlayerManager.Instance.PlayerSpawnState())
        {
            if(Input.GetKey(KeyCode.D) && CanMove(Vector2.right))
            {
                direction = Vector2.right;
            }
            if(Input.GetKey(KeyCode.A) && CanMove(Vector2.left))
            {
                direction = Vector2.left;
            }
            if(direction != Vector2.zero && CanMove(direction))
            {
                MovePlayer(direction);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // for testing new stuff in safe enviroment
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(!ObstacleManager.Instance.ObstacleSpawnState())
            {
                ObstacleManager.Instance.ChangeObstacleSpawnState(true);
            }

            ObstacleManager.Instance.SpawnObstacle();
        }
    }

    public void SetPlayerSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction * playerSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private bool CanMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.55f);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.name == "LeftWall" || hit.collider.gameObject.name == "RightWall")
            {
                return false;
            }
        }

        return true;
    }
}