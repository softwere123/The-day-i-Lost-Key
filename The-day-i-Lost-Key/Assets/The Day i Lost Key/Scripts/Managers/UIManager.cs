using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // UI ��ҵ� (���, ȸ�� ��ư ��)
    public GameObject dialogueTextObject;
    public GameObject memoryButton;
    public GameObject cutsceneButton;

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���¿� �´� UI ������Ʈ
    public void UpdateUI(GameState currentState)
    {
        switch (currentState)
        {
            case GameState.Exploring:
                dialogueTextObject.SetActive(true);  // ��� ǥ��
                memoryButton.SetActive(true);  // ȸ�� �� ��ư Ȱ��ȭ
                cutsceneButton.SetActive(false);  // �ƾ� ��ư ��Ȱ��ȭ
                break;

            case GameState.MemoryScene:
                dialogueTextObject.SetActive(false);  // ��� ��Ȱ��ȭ
                memoryButton.SetActive(false);  // ȸ�� �� ��ư ��Ȱ��ȭ
                cutsceneButton.SetActive(false);  // �ƾ� ��ư ��Ȱ��ȭ
                break;

            case GameState.Cutscene:
                dialogueTextObject.SetActive(false);  // ��� ��Ȱ��ȭ
                memoryButton.SetActive(false);  // ȸ�� �� ��ư ��Ȱ��ȭ
                cutsceneButton.SetActive(true);  // �ƾ� ��ư Ȱ��ȭ
                break;
        }
    }
}
