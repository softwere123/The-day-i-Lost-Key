using UnityEngine.SceneManagement;
using UnityEngine;

public class EndMemoryScene : MonoBehaviour
{
    public void ReturnToMainScene()
    {
        string returnScene = GameManager.Instance.returnSceneName;
        if (!string.IsNullOrEmpty(returnScene))
        {
            SceneManager.LoadScene(returnScene);  // ����� ������ ���ư���
        }
        else
        {
            Debug.LogWarning("���ư� �� ������ �����ϴ�.");
        }
    }
}