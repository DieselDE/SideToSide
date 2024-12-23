using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance;
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
        if (GameManager.Instance.State == GameState.Game)
        {
            CurrentValue++;
            CounterText.text = ((int)CurrentValue / 100).ToString();
        }
    }

    public void StartUp()
    {
        CurrentValue = 0;
        CounterText.text = CurrentValue.ToString();

        Debug.Log("Counter initialized");
    }
}