using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    private int currentIndex = 0;
    private StoryNode[] storyNodes;  // 스토리 노드 배열

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

    public void AdvanceStory()
    {
        if (currentIndex < storyNodes.Length)
        {
            StoryNode node = storyNodes[currentIndex];
            DisplayDialogue(node.dialogueText);  // 대사 출력

            // 회상 씬으로 이동
            if (!string.IsNullOrEmpty(node.memorySceneName))
            {
                GameManager.Instance.returnSceneName = SceneManager.GetActiveScene().name;  // 돌아갈 씬 저장
                StartCoroutine(LoadMemoryScene(node.memorySceneName));
            }
            else
            {
                currentIndex++;
            }
        }
    }

    private void DisplayDialogue(string dialogue)
    {
        // 대사 출력 코드 (UI로 전달될 대사를 UIManager에 넘기거나 대사박스를 활성화하는 등의 작업)
        UIManager.Instance.DisplayDialogue(dialogue);
    }

    private IEnumerator LoadMemoryScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);  // 잠시 대사를 감상할 수 있는 시간

        SceneManager.LoadScene(sceneName);  // 회상 씬 로드
    }
}
