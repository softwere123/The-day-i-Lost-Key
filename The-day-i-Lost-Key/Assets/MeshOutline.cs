using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshOutline : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineWidth = 1.05f;

    private GameObject outlineObject;

    void Start()
    {
        CreateOutline();
        HideOutline();
    }

    void CreateOutline()
    {
        outlineObject = new GameObject("Outline");
        outlineObject.transform.SetParent(transform);
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one * outlineWidth;

        MeshFilter sourceMF = GetComponent<MeshFilter>();
        MeshRenderer sourceMR = GetComponent<MeshRenderer>();

        MeshFilter outlineMF = outlineObject.AddComponent<MeshFilter>();
        outlineMF.mesh = sourceMF.mesh;

        MeshRenderer outlineMR = outlineObject.AddComponent<MeshRenderer>();
        Material outlineMat = new Material(Shader.Find("Unlit/Color"));
        outlineMat.color = outlineColor;
        outlineMR.material = outlineMat;

        outlineMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineMR.receiveShadows = false;
    }

    void OnMouseEnter()
    {
        ShowOutline();
    }

    void OnMouseExit()
    {
        HideOutline();
    }

    public void ShowOutline()
    {
        if (outlineObject != null)
            outlineObject.SetActive(true);
    }

    public void HideOutline()
    {
        if (outlineObject != null)
            outlineObject.SetActive(false);
    }
}
