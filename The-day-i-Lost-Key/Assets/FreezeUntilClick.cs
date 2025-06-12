using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FreezeUntilClick : MonoBehaviour
{
    private Rigidbody rb;
    private bool unlocked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 처음에는 모든 움직임 및 회전 고정
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update()
    {
        // 마우스 왼쪽 클릭 시 움직임 및 회전 해제
        if (!unlocked && Input.GetMouseButtonDown(0))
        {
            rb.constraints = RigidbodyConstraints.None;
            unlocked = true;
            Debug.Log("이동 및 회전 해제됨");
        }

        // (선택) 다시 고정하고 싶다면 아래 코드 참고
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     rb.constraints = RigidbodyConstraints.FreezeAll;
        //     unlocked = false;
        //     Debug.Log("다시 고정됨");
        // }
    }
}
