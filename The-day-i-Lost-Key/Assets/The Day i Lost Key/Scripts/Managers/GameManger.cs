using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameState
{
    Exploring,
    MemoryScene,
    Cutscene
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    public string returnSceneName;  // 돌아갈 씬 이름을 저장하는 변수

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

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("게임 상태 변경됨: " + newState);

        // UI 상태 갱신
        UIManager.Instance.UpdateUI(newState);  // UI 상태 갱신 호출
    }
}