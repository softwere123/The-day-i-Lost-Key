using UnityEngine;

public class SimpleOutline : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;    // 외곽선 머티리얼
    private Material[] originalMaterials;                 // 원래 머티리얼들
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalMaterials = rend.materials;
        }
    }

    public void ShowOutline()
    {
        if (rend == null || outlineMaterial == null) return;

        // 원래 머티리얼 + 외곽선 머티리얼 추가
        Material[] mats = new Material[originalMaterials.Length + 1];
        originalMaterials.CopyTo(mats, 0);
        mats[mats.Length - 1] = outlineMaterial;

        rend.materials = mats;
    }

    public void HideOutline()
    {
        if (rend == null) return;

        // 원래 머티리얼로 복구
        rend.materials = originalMaterials;
    }
}
