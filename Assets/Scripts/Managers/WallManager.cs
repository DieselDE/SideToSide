using UnityEngine;

public class WallManager : MonoBehaviour
{
    public static WallManager instance;

    void awake()
    {
        instance = this;
    }
}
