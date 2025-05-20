using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    // 각 선택 오브젝트가 보여줄 오브젝트 매핑
    [System.Serializable]
    public class SelectionTargetPair
    {
        public GameObject selectableObject;
        public GameObject targetToActivate;
    }

    public List<SelectionTargetPair> selectionTargets = new List<SelectionTargetPair>();

    private List<GameObject> activeTargets = new List<GameObject>();

    void Update()
    {
        // ESC 키 누르면 모든 활성화된 오브젝트 비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var obj in activeTargets)
            {
                if (obj != null) obj.SetActive(false);
            }
            activeTargets.Clear();
            return;
        }

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var selected = hit.transform.gameObject;
                if (selected.CompareTag(selectableTag))
                {
                    foreach (var pair in selectionTargets)
                    {
                        if (pair.selectableObject == selected)
                        {
                            pair.targetToActivate.SetActive(true);
                            activeTargets.Add(pair.targetToActivate);
                            break;
                        }
                    }
                }
            }
        }
    }
}
