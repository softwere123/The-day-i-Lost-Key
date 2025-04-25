using UnityEngine;

[System.Serializable]
public class StoryNode
{
    public string dialogueText;    // 대사
    public GameObject triggerObject; // 트리거 오브젝트
    public string memorySceneName;  // 회상 씬 이름 (비어있지 않으면 씬 전환)
}