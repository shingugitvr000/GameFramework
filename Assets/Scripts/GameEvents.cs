// ���� ��ü���� ����� �̺�Ʈ ����
public static class GameEvents
{
    public static System.Action<string> OnSceneChanged;
    public static System.Action<float> OnVolumeChanged;
    public static System.Action<int> OnScoreChanged;
    public static System.Action OnGamePaused;
    public static System.Action OnGameResumed;

    // �̺�Ʈ ȣ�� �޼����
    public static void SceneChanged(string sceneName) => OnSceneChanged?.Invoke(sceneName);
    public static void VolumeChanged(float volume) => OnVolumeChanged?.Invoke(volume);
    public static void ScoreChanged(int score) => OnScoreChanged?.Invoke(score);
    public static void GamePaused() => OnGamePaused?.Invoke();
    public static void GameResumed() => OnGameResumed?.Invoke();
}