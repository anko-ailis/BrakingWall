using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要
using UnityEngine.UI;              // UIボタンに必要

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button startButton; // Inspectorでボタンを割り当て
    [SerializeField] private string gameSceneName = "RyougaScene"; // ゲームシーン名

    private void Awake()
    {
        // 入力チェック
        if (startButton == null)
        {
            Debug.LogError("StartButton が Inspector に設定されていません。");
            enabled = false;
            return;
        }

        if (string.IsNullOrWhiteSpace(gameSceneName))
        {
            Debug.LogError("GameSceneName が設定されていません。");
            enabled = false;
            return;
        }

        // ボタンにクリックイベントを登録
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    /// <summary>
    /// スタートボタンが押されたときに呼ばれる処理
    /// </summary>
    private void OnStartButtonClicked()
    {
        // シーン切り替え
        try
        {
            SceneManager.LoadScene(gameSceneName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"シーン切り替えに失敗しました: {ex.Message}");
        }
    }
}
