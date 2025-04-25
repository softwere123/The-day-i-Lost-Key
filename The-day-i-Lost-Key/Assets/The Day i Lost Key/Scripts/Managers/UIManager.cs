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
        dialogueTextObject.SetActive(true);  // 대사 텍스트를 활성화
        dialogueTextComponent.text = dialogue;  // 대사 텍스트 업데이트
    }

    public void HideDialogue()
    {
        dialogueTextObject.SetActive(false);  // 대사 텍스트 숨기기
    }
}
