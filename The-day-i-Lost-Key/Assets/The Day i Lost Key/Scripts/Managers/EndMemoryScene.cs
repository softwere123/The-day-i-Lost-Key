using UnityEngine.SceneManagement;
using UnityEngine;

public class EndMemoryScene : MonoBehaviour
{
    public void ReturnToMainScene()
    {
        string returnScene = GameManager.Instance.returnSceneName;
        if (!string.IsNullOrEmpty(returnScene))
        {
            SceneManager.LoadScene(returnScene);  // 저장된 씬으로 돌아가기
        }
        else
        {
            Debug.LogWarning("돌아갈 씬 정보가 없습니다.");
        }
    }
}