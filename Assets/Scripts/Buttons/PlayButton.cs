using UnityEngine;
using UnityEngine.UI;

public class PlayButton : Button
{
    public void OnButtonClick()
    {

        Debug.Log($"ButtonPressed!");

        GameManager.Instance.UpdateGameState(GameState.Game);
        gameObject.SetActive(false);
    }
}