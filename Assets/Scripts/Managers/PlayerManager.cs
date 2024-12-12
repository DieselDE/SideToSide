using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager _instance;
    private bool PlayerCanMove;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        PlayerCanMove = false;
    }

    void Update()
    {

    }

    public void playerEnd(bool state)
    {
        PlayerCanMove = state;
    }

    public bool playerState()
    {
        return PlayerCanMove;
    }
}
