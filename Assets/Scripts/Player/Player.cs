using UnityEngine;

public class Player : BasePlayer
{
    void Update()
    {
        Vector2 direction = Vector2.zero;

        if(Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if(Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if(direction != Vector2.zero)
        {
            movePlayer(direction);
        }
    }
}
