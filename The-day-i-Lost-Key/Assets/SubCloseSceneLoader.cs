using UnityEngine;
using UnityEngine.SceneManagement;

public class SubCloseSceneLoader : MonoBehaviour
{
    public GameObject Sub;                  // 추적할 UI 오브젝트
    public string sceneToLoad = "scene_2";  // 이동할 씬 이름

    private bool previousState = false;     // 이전 프레임에서 Sub의 상태

    void Update()
    {
        if (Sub == null) return;

        bool currentState = Sub.activeSelf;

        // 이전 프레임엔 켜져 있었고, 이번 프레임엔 꺼졌다면 → 씬 전환
        if (previousState && !currentState)
        {
            Debug.Log("Sub가 꺼짐 감지됨 → 씬 전환");
            SceneManager.LoadScene(sceneToLoad);
        }

        previousState = currentState; // 상태 업데이트
    }
}
