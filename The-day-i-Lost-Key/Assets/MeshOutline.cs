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
        HideOutline(); // 처음에는 Outline 숨김
    }

    void CreateOutline()
    {
        outlineObject = new GameObject("Outline");
        outlineObject.transform.SetParent(transform);
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one * outlineWidth;

        // 원본 메쉬 복사
        MeshFilter sourceMF = GetComponent<MeshFilter>();
        MeshRenderer sourceMR = GetComponent<MeshRenderer>();

        MeshFilter outlineMF = outlineObject.AddComponent<MeshFilter>();
        outlineMF.mesh = sourceMF.mesh;

        MeshRenderer outlineMR = outlineObject.AddComponent<MeshRenderer>();

        // 안정적인 쉐이더 찾기
        Shader outlineShader = Shader.Find("Sprites/Default");
        if (outlineShader == null)
        {
            Debug.LogError("Outline 쉐이더(Sprites/Default)를 찾을 수 없습니다. 다른 쉐이더로 대체하거나 프로젝트 설정 확인 필요.");
            return;
        }

        Material outlineMat = new Material(outlineShader);
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
