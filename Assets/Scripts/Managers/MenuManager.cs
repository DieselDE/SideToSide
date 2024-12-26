using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int highestValue;

    public static MenuManager Instance;
    public GameObject HighestValueCanvasPrefab;
    public GameObject HighestValueCanvas;
    public TMP_Text HighestValueText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        CheckDeleteState();
    }

    public void StartUp()
    {
        if(GameManager.Instance.State == GameState.Defeat)
        {
            SpawnHighestValue();
            UpdateHighestValue();
            UpdateText();
        }
    }

    public int GetHighestValue() { return highestValue; }
    public void ChangeHighestValue(int value) { highestValue = value; }


    public void SpawnHighestValue()
    {
        HighestValueCanvas = Instantiate(HighestValueCanvasPrefab);

        Transform textTransform = HighestValueCanvas.transform.Find("HighestValueText");
        if(textTransform != null)
        {
            HighestValueText = textTransform.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("Child object 'HighestValueText' not found in the canvas!");
        }
    }

    public void UpdateHighestValue()
    {
        int CurrentValue = CounterManager.Instance.GetCurrentValue();

        if (PlayerPrefs.HasKey("SavedhighestValue"))
        {
            if (CurrentValue > PlayerPrefs.GetInt("SavedhighestValue"))
            {
                PlayerPrefs.SetInt("SavedhighestValue", CurrentValue);
                highestValue = CurrentValue;
            }
            else
            {
                highestValue = PlayerPrefs.GetInt("SavedhighestValue");
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedhighestValue", CurrentValue);
            highestValue = CurrentValue;
        }

        CounterManager.Instance.DeleteCounter();
    }

    public void UpdateText()
    {
        HighestValueText.text = highestValue.ToString();
    }

    public void CheckDeleteState()
    {
        if (GameManager.Instance.State != GameState.Defeat)
        {
            Destroy(HighestValueCanvas);
        }
    }
}
