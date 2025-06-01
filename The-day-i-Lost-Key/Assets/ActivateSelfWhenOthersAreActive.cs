using UnityEngine;

public class ActivateSelfWhenOthersAreActive : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject targetSelf; // 자기 자신을 켤 오브젝트

    void Update()
    {
        if (obj1 != null && obj2 != null && targetSelf != null)
        {
            if (obj1.activeSelf && obj2.activeSelf && !targetSelf.activeSelf)
            {
                targetSelf.SetActive(true);
                Debug.Log("자기 자신 켜짐");
            }
        }
    }
}
