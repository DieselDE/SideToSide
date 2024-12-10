using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    void awake()
    {
        instance = this;
    }
}
