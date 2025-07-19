using UnityEngine;

// ������ ���� ���̽� Ŭ����
public class Actor : MonoBehaviour
{
    public bool canUpdate = true;

    protected virtual void Update()
    {
        if (CanAct())
        {
            ActorUpdate();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (CanAct())
        {
            ActorFixedUpdate();
        }
    }

    // ���Ͱ� ������ �� �ִ��� Ȯ��
    protected bool CanAct()
    {
        if (!canUpdate) return false;
        if (GameManager.Instance == null) return true;

        GameState state = GameManager.Instance.currentGameState;
        return state == GameState.Playing;
    }

    // ��ӹ޾Ƽ� ������ �޼ҵ��
    protected virtual void ActorUpdate() { }
    protected virtual void ActorFixedUpdate() { }
}