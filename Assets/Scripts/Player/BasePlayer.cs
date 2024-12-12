using UnityEngine;

public class BasePlayer : PlayerManager
{
    private float _playerSpeed = 100f;
    public ScriptablePlayer _scriptablePlayer;

    public void setScriptablePlayer(ScriptablePlayer scriptablePlayer)
    {
        _scriptablePlayer = scriptablePlayer;
    }

    /*
     * Moves the Player with certain speed
     * -> thinking about changing it so that it moves the player
     * -> in one direction until new user-input occurs
     */
    public void movePlayer(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction * _playerSpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    }
}
