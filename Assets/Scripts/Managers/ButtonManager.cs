using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        Debug.Log($"ButtonPressed!");
        
        GameManager.Instance.UpdateGameState(GameState.Game);
        gameObject.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        Debug.Log("Exiting Game!");
        Application.Quit();
    }
}
