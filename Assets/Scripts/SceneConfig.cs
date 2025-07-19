using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SceneStatePair
{
    public string sceneName;
    public GameState gameState;
}

public class SceneConfig : SingletonMonoBehaviour<SceneConfig>
{
    [Header("Scene State Settings")]
    public GameState defaultState = GameState.Menu;

    [Header("Scene Configurations")]
    public List<SceneStatePair> sceneConfigs = new List<SceneStatePair>();

    private Dictionary<string, GameState> sceneStates = new Dictionary<string, GameState>();

    protected override void Awake()
    {
        base.Awake();
        SetupSceneStates();
        GameEvents.OnSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        GameEvents.OnSceneChanged -= OnSceneChanged;
    }

    private void SetupSceneStates()
    {
        sceneStates.Clear();

        foreach (var config in sceneConfigs)
        {
            if (!string.IsNullOrEmpty(config.sceneName))
            {
                sceneStates[config.sceneName] = config.gameState;
            }
        }
    }

    private void OnSceneChanged(string sceneName)
    {
        GameState targetState = sceneStates.ContainsKey(sceneName) ? sceneStates[sceneName] : defaultState;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeGameState(targetState);
        }

        Debug.Log($"�� '{sceneName}' -> ����: {targetState}");
    }

    // ��Ÿ�ӿ��� �� ���� ����
    public void SetSceneState(string sceneName, GameState state)
    {
        sceneStates[sceneName] = state;
    }
}