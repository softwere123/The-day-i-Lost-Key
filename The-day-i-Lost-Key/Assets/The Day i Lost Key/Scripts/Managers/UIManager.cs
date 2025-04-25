using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // UI 요소들 (대사, 회상 버튼 등)
    public GameObject dialogueTextObject;
    public GameObject memoryButton;
    public GameObject cutsceneButton;

    private void Awake()
    {
        // 싱글턴 패턴
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

    // 상태에 맞는 UI 업데이트
    public void UpdateUI(GameState currentState)
    {
        switch (currentState)
        {
            case GameState.Exploring:
                dialogueTextObject.SetActive(true);  // 대사 표시
                memoryButton.SetActive(true);  // 회상 씬 버튼 활성화
                cutsceneButton.SetActive(false);  // 컷씬 버튼 비활성화
                break;

            case GameState.MemoryScene:
                dialogueTextObject.SetActive(false);  // 대사 비활성화
                memoryButton.SetActive(false);  // 회상 씬 버튼 비활성화
                cutsceneButton.SetActive(false);  // 컷씬 버튼 비활성화
                break;

            case GameState.Cutscene:
                dialogueTextObject.SetActive(false);  // 대사 비활성화
                memoryButton.SetActive(false);  // 회상 씬 버튼 비활성화
                cutsceneButton.SetActive(true);  // 컷씬 버튼 활성화
                break;
        }
    }
}
