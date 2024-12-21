using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int currentValue;

    public TMP_Text CounterText;

    public void StartUp()
    {
        currentValue = 0;
        UpdateCounterText();
        Debug.Log("Counter initialized");
    }

    public void Increment()
    {
        currentValue++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (CounterText != null)
        {
            CounterText.text = ((int)currentValue / 100).ToString();
        }
    }
}
