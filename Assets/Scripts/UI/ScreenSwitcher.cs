using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject spinScreen;
    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;    

    private GameObject currentScreen;

    private void Awake()
    {
        currentScreen = mainMenu;
    }

    private void Start()
    {
        EventManager.GameStarted += ShowGameplay;
        EventManager.YouWin += ShowWinScreen;
        EventManager.YouLose += ShowLoseScreen;
    }

    public void ShowMainMenu()
    {
        currentScreen.SetActive(false);
        currentScreen = mainMenu;
        currentScreen.SetActive(true);
    }

    public void ShowSpinScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = spinScreen;
        currentScreen.SetActive(true);
    }

    public void ShowGameplay()
    {
        currentScreen.SetActive(false);
        currentScreen = gameplayScreen;
        currentScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = winScreen;
        currentScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = loseScreen;
        currentScreen.SetActive(true);
    }
}
