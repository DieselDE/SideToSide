using UnityEngine;

public class CounterManager : MonoBehaviour
{
    private GameObject activeCounter;
    private Counter counterComponent;

    public static CounterManager Instance;
    public GameObject CounterPrefab;

    void Awake()
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
        if(GameManager.Instance.State == GameState.PlayerMove)
        {
            IncrementCounter();
        }
    }

    public void StartUp()
    {
        SpawnCounter();
        Debug.Log("CounterManager initialized");
    }

    public void SpawnCounter()
    {
        if (CounterPrefab != null && activeCounter == null)
        {
            activeCounter = Instantiate(CounterPrefab);
            counterComponent = activeCounter.GetComponent<Counter>();

            Canvas canvas = activeCounter.GetComponent<Canvas>();
            if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                canvas.worldCamera = Camera.main;
            }

            counterComponent.StartUp();
        }
    }


    public void DestroyCounter()
    {
        if (activeCounter != null)
        {
            Destroy(activeCounter);
            activeCounter = null;
            counterComponent = null;
        }
    }

    public void IncrementCounter()
    {
        if (counterComponent != null)
        {
            counterComponent.Increment();
        }
    }
}
