using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;
    public GameObject ButtonCanvasPrefab;
    public PlayButton PlayButtonPrefab;
    public ExitButton ExitButtonPrefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartUp()
    {
        if(GameManager.Instance.State == GameState.Menu)
        {
            SpawnButtons();
            Debug.Log("Initialized Buttons!");
            return;
        }

        Debug.LogError("Wrong GameState ;)");
    }

    public void SpawnButtons()
    {

        GameObject buttonCanvas = Instantiate(ButtonCanvasPrefab);

        PlayButton playButton = Instantiate(PlayButtonPrefab, transform);
        playButton.onClick.AddListener(() => playButton.OnButtonClick());

        ExitButton exitButton = Instantiate(ExitButtonPrefab, transform);
        exitButton.onClick.AddListener(() => exitButton.OnButtonClick());
    }
}