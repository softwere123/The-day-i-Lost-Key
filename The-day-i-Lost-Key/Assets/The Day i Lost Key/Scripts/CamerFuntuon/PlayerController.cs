using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;
    public Camera playerCamera;
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody ������ ã�� ������ �߰��մϴ�.
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing from Player!");
        }
    }

    void Update()
    {
        // Rigidbody�� ���ٸ� �̵����� ����
        if (rb == null) return;

        // �̵� (WASD)
        float moveX = Input.GetAxis("Horizontal");  // A, D
        float moveZ = Input.GetAxis("Vertical");    // W, S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // ���콺 ȸ�� (�÷��̾� ĳ���� ȸ��)
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        // ī�޶� ȸ�� (����)
        float mouseY = Input.GetAxis("Mouse Y");
        playerCamera.transform.Rotate(-mouseY * rotationSpeed * Time.deltaTime, 0f, 0f);
    }
}
