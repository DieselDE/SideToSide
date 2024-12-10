using UnityEngine;

public class BasePlayer : PlayerManager
{
    public ScriptablePlayer _scriptablePlayer;

    public void setScriptablePlayer(ScriptablePlayer scriptablePlayer)
    {
        _scriptablePlayer = scriptablePlayer;
    }

    private float _playerSpeed = 5f;

    public void movePlayer(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction * _playerSpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    }
}
