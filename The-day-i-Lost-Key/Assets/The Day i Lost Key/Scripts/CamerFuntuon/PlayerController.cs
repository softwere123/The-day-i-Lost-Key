using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;
    public Camera playerCamera;
    private Rigidbody rb;

    void Awake()
    {
        // Rigidbody 초기화
        rb = GetComponent<Rigidbody>();

        // Rigidbody가 없다면 오류 메시지를 출력
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing from Player!");
            return;
        }

      
    }

    void Update()
    {
        // Rigidbody가 없으면 이동하지 않음
        if (rb == null) return;

        // 이동 (WASD)
        float moveX = Input.GetAxis("Horizontal");  // A, D
        float moveZ = Input.GetAxis("Vertical");    // W, S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // 마우스 회전 (플레이어 캐릭터 회전)
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        // 카메라 회전 (상하)
        float mouseY = Input.GetAxis("Mouse Y");
        playerCamera.transform.Rotate(-mouseY * rotationSpeed * Time.deltaTime, 0f, 0f);
    }
}
