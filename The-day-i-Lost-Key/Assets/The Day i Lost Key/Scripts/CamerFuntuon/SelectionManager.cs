using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";   // 선택 가능한 태그
    [SerializeField] private GameObject[] objectsToActivate;        // 클릭 시 활성화할 오브젝트들

    private Transform _selection;

    void Update()
    {
        // 이전 선택 해제 (Outline 끄기)
        if (_selection != null)
        {
            var outline = _selection.GetComponent<SimpleOutline>();  // 여기 바꿈
            if (outline != null)
            {
                outline.HideOutline();
            }
        }

        _selection = null;

        // Raycasting - 마우스 위치에서 레이 쏘기
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        // 현재 선택한 오브젝트 Outline 켜기
        if (_selection != null)
        {
            var outline = _selection.GetComponent<SimpleOutline>();  // 여기 바꿈
            if (outline != null)
            {
                outline.ShowOutline();
            }
        }

        // 클릭 시 처리 (좌클릭)
        if (Input.GetMouseButtonDown(0))
        {
            if (_selection != null)
            {
                foreach (var obj in objectsToActivate)
                {
                    if (obj != null)
                        obj.SetActive(true);
                }
            }
        }

        // ESC 키 누르면 활성화된 오브젝트 모두 비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var obj in objectsToActivate)
            {
                if (obj != null && obj.activeSelf)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
