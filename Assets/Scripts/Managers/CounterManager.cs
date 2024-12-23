using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;
    public int CurrentValue;
    public TMP_Text CounterText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Update()
    {
        UpdateText();
    }

    public void StartUp()
    {
        CurrentValue = 0;
        CounterText.text = CurrentValue.ToString();

        Debug.Log("Counter initialized");
    }

    public void AddToCounter()
    {
        CurrentValue++;
    }

    public void UpdateText()
    {
        if (GameManager.Instance.State == GameState.Game)
        {
            CounterText.text = CurrentValue.ToString();
        }
    }
}
