using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;

    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        // Movement
        if (PlayerManager.Instance.GetPlayerCanMove())
        {
            if (Input.GetKey(KeyCode.D))
            {
                direction = Vector2.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector2.left;
            }
            if (direction != Vector2.zero && CanMove())
            {
                MovePlayer();
            }

            // check if obstacle hit
            if (HitObstacle())
            {
                Debug.Log("Hit an Obstacle");
                GameManager.Instance.UpdateGameState(GameState.Defeat);
            }
        }

        // Check for state of game
        CheckDeleteState();

        // Exit application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SpawnPlayer()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.color = GetColorFromPlayerColor(PlayerManager.Instance.PlayerData.PlayerColor);
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

    public void MovePlayer()
    {
        Vector3 newPosition = transform.position + (Vector3)direction * PlayerManager.Instance.GetPlayerSpeed() * Time.deltaTime;
        transform.position = newPosition;
    }

    public bool CanMove()
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

    public bool HitObstacle()
    {
        RaycastHit2D hitSide = Physics2D.Raycast(transform.position, direction, 0.1f);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 0.1f);

        if( hitSide.collider != null || hitUp.collider != null)
        {
            if(hitSide.collider.gameObject.name == "SquareObstacle(Clone)" || hitUp.collider.gameObject.name == "SquareObstacle(Clone)")
            {
                return true;
            }
        }

        return false;
    }

    public void CheckDeleteState()
    {
        if(GameManager.Instance.State == GameState.Defeat)
        {
            Destroy(gameObject);
        }
    }
}