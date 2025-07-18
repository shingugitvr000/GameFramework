using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestSceneUI : MonoBehaviour
{
    [Header("UI References")]
    public Button loadGameSceneButton;
    public Button loadMainMenuButton;
    public Button reloadSceneButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button addScoreButton;
    public Button gameOverButton;

    [Header("Display")]
    public TextMeshProUGUI currentSceneText;
    public TextMeshProUGUI gameStateText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loadingProgressText;
    public Slider loadingProgressSlider;

    private void Start()
    {
        SetupButtons();
        UpdateUI();

        // �̺�Ʈ ����
        GameEvents.OnSceneChanged += OnSceneChanged;
        GameEvents.OnScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        // �̺�Ʈ ���� ����
        GameEvents.OnSceneChanged -= OnSceneChanged;
        GameEvents.OnScoreChanged -= OnScoreChanged;
    }

    private void Update()
    {
        UpdateUI();
    }

    private void SetupButtons()
    {
        // �� �ε� ��ư��
        if (loadGameSceneButton != null)
            loadGameSceneButton.onClick.AddListener(() => SceneManager.Instance.LoadScene("GameScene"));

        if (loadMainMenuButton != null)
            loadMainMenuButton.onClick.AddListener(() => SceneManager.Instance.LoadMainMenu());

        if (reloadSceneButton != null)
            reloadSceneButton.onClick.AddListener(() => SceneManager.Instance.ReloadCurrentScene());

        // ���� �Ŵ��� ��ư��
        if (pauseButton != null)
            pauseButton.onClick.AddListener(() => GameManager.Instance.PauseGame());

        if (resumeButton != null)
            resumeButton.onClick.AddListener(() => GameManager.Instance.ResumeGame());

        if (addScoreButton != null)
            addScoreButton.onClick.AddListener(() => GameManager.Instance.AddScore(100));

        if (gameOverButton != null)
            gameOverButton.onClick.AddListener(() => GameManager.Instance.GameOver());
    }

    private void UpdateUI()
    {
        // ���� �� �̸� ǥ��
        if (currentSceneText != null && SceneManager.Instance != null)
        {
            currentSceneText.text = $"���� ��: {SceneManager.Instance.GetCurrentSceneName()}";
        }

        // ���� ���� ǥ��
        if (gameStateText != null && GameManager.Instance != null)
        {
            gameStateText.text = $"���� ����: {GameManager.Instance.currentGameState}";

            // �Ͻ����� ���¸� ���� ����
            if (GameManager.Instance.currentGameState == GameState.Paused)
            {
                gameStateText.color = Color.red;
            }
            else
            {
                gameStateText.color = Color.white;
            }
        }

        // ���� ǥ��
        if (scoreText != null && GameManager.Instance != null)
        {
            scoreText.text = $"����: {GameManager.Instance.currentScore:N0}";
        }

        // �ε� ����� ǥ��
        if (SceneManager.Instance != null && SceneManager.Instance.IsLoading())
        {
            float progress = SceneManager.Instance.LoadingProgress;

            if (loadingProgressText != null)
            {
                loadingProgressText.text = $"�ε� ��... {progress * 100:F1}%";
                loadingProgressText.gameObject.SetActive(true);
            }

            if (loadingProgressSlider != null)
            {
                loadingProgressSlider.value = progress;
                loadingProgressSlider.gameObject.SetActive(true);
            }
        }
        else
        {
            if (loadingProgressText != null)
                loadingProgressText.gameObject.SetActive(false);

            if (loadingProgressSlider != null)
                loadingProgressSlider.gameObject.SetActive(false);
        }
    }

    private void OnSceneChanged(string sceneName)
    {
        Debug.Log($"�� ���� �̺�Ʈ ����: {sceneName}");
    }

    private void OnScoreChanged(int newScore)
    {
        Debug.Log($"���� ���� �̺�Ʈ ����: {newScore}");
    }

    // ����׿� �޼����
    public void DebugCurrentState()
    {
        Debug.Log($"=== ���� ���� ===");
        Debug.Log($"��: {SceneManager.Instance?.GetCurrentSceneName()}");
        Debug.Log($"���� ����: {GameManager.Instance?.currentGameState}");
        Debug.Log($"����: {GameManager.Instance?.currentScore}");
        Debug.Log($"�ε� ��: {SceneManager.Instance?.IsLoading()}");
    }
}