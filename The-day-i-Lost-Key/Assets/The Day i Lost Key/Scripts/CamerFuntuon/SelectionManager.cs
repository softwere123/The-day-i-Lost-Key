using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [System.Serializable]
    public class SelectableObject
    {
        public GameObject selectable;    // 클릭할 대상
        public GameObject targetObject;  // 클릭 시 보여줄 오브젝트 (예: 영상)
    }

    [SerializeField]
    private SelectableObject[] selectableObjects;

    [SerializeField]
    private GameObject activateAfterThreeSelected; // 3개 이상 선택되었을 때 켤 오브젝트

    private bool[] hasBeenSelected; // 각 항목이 한 번이라도 켜졌는지 저장
    private int totalSelectedCount = 0;

    void Start()
    {
        hasBeenSelected = new bool[selectableObjects.Length];
    }

    void Update()
    {
        // ESC 키 누르면 현재 열려있는 오브젝트만 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var so in selectableObjects)
            {
                so.targetObject.SetActive(false);

                // 아웃라인 끄기
                var outline = so.selectable.GetComponent<MeshOutline>();
                if (outline != null)
                    outline.HideOutline();
            }
            return;
        }

        // 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                for (int i = 0; i < selectableObjects.Length; i++)
                {
                    var so = selectableObjects[i];

                    if (hit.transform.gameObject == so.selectable)
                    {
                        // 오브젝트 활성화
                        so.targetObject.SetActive(true);

                        // 아웃라인 활성화
                        var outline = so.selectable.GetComponent<MeshOutline>();
                        if (outline != null)
                            outline.ShowOutline();

                        // 처음 선택된 경우에만 카운트 증가
                        if (!hasBeenSelected[i])
                        {
                            hasBeenSelected[i] = true;
                            totalSelectedCount++;

                            // 3개 이상 선택되면 지정된 오브젝트 켜기
                            if (totalSelectedCount >= 4 && activateAfterThreeSelected != null)
                            {
                                activateAfterThreeSelected.SetActive(true);
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}
