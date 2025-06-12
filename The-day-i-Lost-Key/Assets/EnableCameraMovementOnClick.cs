using UnityEngine;

public class EnableCameraMovementOnClick : MonoBehaviour
{
    public GameObject activationTarget; // 클릭할 대상
    public MonoBehaviour[] scriptsToEnable; // 활성화할 회전/이동 스크립트들

    private bool activated = false;

    void Start()
    {
        // 시작 시 모두 비활성화
        foreach (var script in scriptsToEnable)
        {
            if (script != null)
                script.enabled = false;
        }
    }

    void Update()
    {
        if (activated) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject == activationTarget)
                {
                    foreach (var script in scriptsToEnable)
                    {
                        if (script != null)
                            script.enabled = true;
                    }

                    activated = true;
                }
            }
        }
    }
}
