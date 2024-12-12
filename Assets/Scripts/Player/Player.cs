using System;
using UnityEngine;

public class Player : BasePlayer
{
    private Vector2 direction;

    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(GameManager._instance._state == GameState.PlayerMove)
            {
                GameManager._instance.updateGameState(GameState.End);
            }
            else if(GameManager._instance._state == GameState.End)
            {
                GameManager._instance.updateGameState(GameState.PlayerMove);
            }
        }

        // PlayerMovement
        if (PlayerManager._instance.playerState())
        {
            if (Input.GetKeyDown(KeyCode.D) && canMove(Vector2.right))
            {
                direction = Vector2.right;
            }
            if (Input.GetKeyDown(KeyCode.A) && canMove(Vector2.left))
            {
                direction = Vector2.left;
            }
            if (direction != Vector2.zero && canMove(direction))
            {
                movePlayer(direction);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /*
     * Check if Player can move through object
     * -> thinking about adding a list with all objects and only go through the list
     */
    private bool canMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.55f);
        
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.name == "WallLeft" || hit.collider.gameObject.name == "WallRight")
            {
                return false;
            }
        }

        return true;
    }
}
