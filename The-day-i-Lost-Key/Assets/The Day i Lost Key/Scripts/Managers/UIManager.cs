using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject dialogueTextObject;
    public UnityEngine.UI.Text dialogueTextComponent;

    private void Awake()
    {
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

    public void DisplayDialogue(string dialogue)
    {
        dialogueTextObject.SetActive(true);  // ��� �ؽ�Ʈ�� Ȱ��ȭ
        dialogueTextComponent.text = dialogue;  // ��� �ؽ�Ʈ ������Ʈ
    }

    public void HideDialogue()
    {
        dialogueTextObject.SetActive(false);  // ��� �ؽ�Ʈ �����
    }
}
