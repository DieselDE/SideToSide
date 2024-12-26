using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    private int CurrentValue;

    public static CounterManager Instance;
    public GameObject CounterCanvasPrefab;
    public GameObject CounterCanvas;
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
        if(GameManager.Instance.State == GameState.Game)
        {
            UpdateText();
        }
    }

    public void StartUp()
    {
        if(GameManager.Instance.State == GameState.Game)
        {
            SpawnCounter();

            CurrentValue = 0;
            CounterText.text = CurrentValue.ToString();

            Debug.Log("Counter initialized");
        }
    }

    public int GetCurrentValue() {  return CurrentValue; }
    public void ChangeCurrentValue(int value) { CurrentValue = value; }

    public void SpawnCounter()
    {
        CounterCanvas = Instantiate(CounterCanvasPrefab);

        Transform textTransform = CounterCanvas.transform.Find("CounterText");
        if (textTransform != null)
        {
            CounterText = textTransform.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("Child object 'CounterText' not found in the canvas prefab!");
        }
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

    public void DeleteCounter()
    {
        Destroy(CounterCanvas);
    }
}
