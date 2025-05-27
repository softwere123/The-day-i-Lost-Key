using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotoSubTransScean : MonoBehaviour
{
    public GameObject Sub;               // ESC로 닫을 UI
    public GameObject triggerObject;     // 클릭될 오브젝트
    public string sceneToLoad = "scene_2";

    private bool triggered = false;      // 클릭 여부

    void Update()
    {
        // 오브젝트 클릭 감지 (Raycast)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == triggerObject)
                {
                    triggered = true;
                    Sub.SetActive(true);
                    Debug.Log("트리거 오브젝트 클릭됨, Sub 활성화");
                }
            }
        }

        // ESC 입력 처리
        if (Input.GetKeyDown(KeyCode.Escape) && Sub.activeSelf)
        {
            Sub.SetActive(false);
            Debug.Log("Sub 비활성화됨");

            if (triggered)
            {
                Debug.Log("씬 전환");
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
