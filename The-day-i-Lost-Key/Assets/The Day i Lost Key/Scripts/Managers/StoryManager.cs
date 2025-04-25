using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    private int currentIndex = 0;
    private StoryNode[] storyNodes;  // ���丮 ��� �迭

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
            DisplayDialogue(node.dialogueText);  // ��� ���

            // ȸ�� ������ �̵�
            if (!string.IsNullOrEmpty(node.memorySceneName))
            {
                GameManager.Instance.returnSceneName = SceneManager.GetActiveScene().name;  // ���ư� �� ����
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
        // ��� ��� �ڵ� (UI�� ���޵� ��縦 UIManager�� �ѱ�ų� ���ڽ��� Ȱ��ȭ�ϴ� ���� �۾�)
        UIManager.Instance.DisplayDialogue(dialogue);
    }

    private IEnumerator LoadMemoryScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);  // ��� ��縦 ������ �� �ִ� �ð�

        SceneManager.LoadScene(sceneName);  // ȸ�� �� �ε�
    }
}
