using UnityEngine;

[CreateAssetMenu(fileName = "new Player", menuName = "Scriptable Player")]
public class ScriptablePlayer : ScriptableObject
{
    public PlayerColor playerColor;
    public BasePlayer playerPrefab;
}

public enum PlayerColor
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