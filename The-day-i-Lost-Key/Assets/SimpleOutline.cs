using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SimpleOutline : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineScale = 1.05f;

    private Material originalMaterial;
    private Material outlineMaterial;
    private Renderer rend;
    private bool isOutlined = false;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogWarning("Renderer 없음");
            enabled = false;
            return;
        }

        if (rend.material == null)
        {
            Debug.LogWarning("기본 메터리얼 없음");
            enabled = false;
            return;
        }

        originalMaterial = rend.material;

        // 기본 Unlit 셰이더
        Shader shader = Shader.Find("Unlit/Color");
        if (shader == null)
        {
            Debug.LogError("Unlit/Color 셰이더 없음");
            enabled = false;
            return;
        }

        outlineMaterial = new Material(shader);
        outlineMaterial.color = outlineColor;
    }

    public void ShowOutline()
    {
        if (!isOutlined && rend != null && outlineMaterial != null)
        {
            rend.material = outlineMaterial;
            transform.localScale *= outlineScale;
            isOutlined = true;
        }
    }

    public void HideOutline()
    {
        if (isOutlined && rend != null && originalMaterial != null)
        {
            rend.material = originalMaterial;
            transform.localScale /= outlineScale;
            isOutlined = false;
        }
    }
}
