using UnityEngine;
using UnityEngine.UI;

public class ExitButton : Button
{
    public void OnButtonClick()
    {

        Debug.Log($"ButtonPressed!");

        Application.Quit();
    }
}