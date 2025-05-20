using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [System.Serializable]
    public class SelectableObject
    {
        public GameObject selectable;    // 클릭할 오브젝트
        public GameObject targetObject;  // 클릭 시 켤 오브젝트 (영상 등)
    }

    [SerializeField]
    private SelectableObject[] selectableObjects;

    private SelectableObject currentSelection = null;
    private MeshOutline currentOutline = null;

    void Update()
    {
        // ESC 눌렀을 때 현재 선택 해제
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentSelection != null)
            {
                if (currentOutline != null)
                    currentOutline.HideOutline();

                currentSelection.targetObject.SetActive(false);

                currentSelection = null;
                currentOutline = null;
            }
            return;
        }

        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                foreach (var so in selectableObjects)
                {
                    if (hit.transform.gameObject == so.selectable)
                    {
                        // 이전 선택 해제
                        if (currentSelection != null)
                        {
                            if (currentOutline != null)
                                currentOutline.HideOutline();

                            currentSelection.targetObject.SetActive(false);
                        }

                        // 새 선택 활성화
                        currentSelection = so;

                        // 아웃라인 켜기
                        currentOutline = currentSelection.selectable.GetComponent<MeshOutline>();
                        if (currentOutline != null)
                            currentOutline.ShowOutline();

                        // 타겟 오브젝트 켜기
                        currentSelection.targetObject.SetActive(true);

                        break;
                    }
                }
            }
        }
    }
}
