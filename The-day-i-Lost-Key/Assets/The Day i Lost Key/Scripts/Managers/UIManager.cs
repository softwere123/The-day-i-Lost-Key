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
        dialogueTextObject.SetActive(true);
        dialogueTextComponent.text = dialogue;
    }

    public void HideDialogue()
    {
        dialogueTextObject.SetActive(false);
    }

    // ⭐ 추가해야 하는 부분 ⭐
    public void UpdateUI(GameState state)
    {
        switch (state)
        {
            case GameState.Exploring:
                HideDialogue();  // 탐험 중이면 대사 끄기
                break;
            case GameState.MemoryScene:
                // 회상 장면이면 대사 띄우기 등 필요한 처리
                break;
            case GameState.Cutscene:
                // 컷씬이면 대사 끄거나 다르게 처리
                HideDialogue();
                break;
        }
    }
}