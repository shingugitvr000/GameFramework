using UnityEngine;
using System.Collections;

// �̺�Ʈ ����� ���� Ŭ����
public class EventSystem : SingletonMonoBehaviour<EventSystem>
{
    public bool isEventPlaying = false;

    // �̺�Ʈ ����
    public void StartEvent()
    {
        if (isEventPlaying) return;

        isEventPlaying = true;
        GameManager.Instance?.PauseGame();

        Debug.Log("�̺�Ʈ ���� - ���� �Ͻ�����");
    }

    // �̺�Ʈ ����
    public void EndEvent()
    {
        if (!isEventPlaying) return;

        isEventPlaying = false;
        GameManager.Instance?.ResumeGame();

        Debug.Log("�̺�Ʈ ���� - ���� �簳");
    }

    // �̺�Ʈ ���� ����
    public void PlayCutscene(float duration)
    {
        StartCoroutine(CutsceneCoroutine(duration));
    }

    private IEnumerator CutsceneCoroutine(float duration)
    {
        StartEvent();

        Debug.Log($"{duration}�� �ƽ� ���");
        yield return new WaitForSecondsRealtime(duration);

        EndEvent();
    }
}