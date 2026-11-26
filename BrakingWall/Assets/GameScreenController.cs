using UnityEngine;
using UnityEngine.UI;

public class GameScreenController : MonoBehaviour
{
    [Header("画面パネル")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("ボタン")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button retryButton;


    private enum ScreenState
    {
        Start,
        Playing,
        GameOver
    }

    private ScreenState currentState = ScreenState.Start;

    private void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if (retryButton != null)
        {
            retryButton.onClick.AddListener(StartGame);
        }
    }

    private void Start()
    {
        ShowStartScreen();
    }

    public void ShowStartScreen()
    {
        currentState = ScreenState.Start;
        Time.timeScale = 0f; // スタート待機中は時間を止める場合

        if (startPanel != null) startPanel.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
       
    }

    public void StartGame()
    {
        currentState = ScreenState.Playing;
        Time.timeScale = 1f;

        if (startPanel != null) startPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
       
        // ここにプレイヤー位置やスコアの初期化処理を入れる
    }

    public void ShowGameOverScreen()
    {
        currentState = ScreenState.GameOver;
        Time.timeScale = 0f;

        if (startPanel != null) startPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        // Enter / Space キーでも開始できるようにする例
        if (currentState == ScreenState.Start && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
}