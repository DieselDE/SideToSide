using UnityEngine;

[CreateAssetMenu(fileName = "new Obstacle", menuName = "Scriptable Obstacle")]
public class ScriptableObstacle : ScriptableObject
{
    public ObstacleColor ObstacleColor;
    public ObstacleForm ObstacleForm;
    public Obstacles ObstaclePrefab;
}

public enum ObstacleColor
{
    White = 0,
    Red = 1,
    Orange = 2,
    Pink = 3,
    Yellow = 4,
    Lime = 5,
    Green = 6,
    LightBlue = 7,
    Cyan = 8,
    Blue = 9,
    Magenta = 10,
    Purple = 11,
    Brown = 12,
    Gray = 13,
    LightGray = 14,
    Black = 15
}

public enum ObstacleForm
{
    Square = 0,
    Rectangle = 1,
    Triangle = 2,
    Circle = 3
}