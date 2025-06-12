using UnityEngine;
using UnityEngine.Video; // VideoPlayer 관련 네임스페이스 추가

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

    private bool[] hasBeenSelected;
    private int totalSelectedCount = 0;

    void Start()
    {
        hasBeenSelected = new bool[selectableObjects.Length];

        // VideoPlayer의 loopPointReached 이벤트로 자동 종료 감지
        foreach (var so in selectableObjects)
        {
            if (so.targetObject != null)
            {
                VideoPlayer vp = so.targetObject.GetComponentInChildren<VideoPlayer>();
                if (vp != null)
                {
                    vp.loopPointReached += OnVideoFinished;
                }
            }
        }
    }

    void Update()
    {
        // ESC 키로 열려있는 오브젝트 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAllTargets();
            return;
        }

        // 마우스 클릭 처리
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
                        // 활성화
                        so.targetObject.SetActive(true);

                        var outline = so.selectable.GetComponent<MeshOutline>();
                        if (outline != null) outline.ShowOutline();

                        if (!hasBeenSelected[i])
                        {
                            hasBeenSelected[i] = true;
                            totalSelectedCount++;

                            if (totalSelectedCount >= 4 && activateAfterThreeSelected != null)
                                activateAfterThreeSelected.SetActive(true);
                        }

                        break;
                    }
                }
            }
        }
    }

    // 모든 대상 오브젝트 끄기
    void CloseAllTargets()
    {
        foreach (var so in selectableObjects)
        {
            if (so.targetObject != null)
                so.targetObject.SetActive(false);

            var outline = so.selectable.GetComponent<MeshOutline>();
            if (outline != null)
                outline.HideOutline();
        }
    }

    // 비디오가 끝났을 때 자동으로 오브젝트 끄기
    void OnVideoFinished(VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
    }
}
