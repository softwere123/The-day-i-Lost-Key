using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshOutline : MonoBehaviour
{
    public Color outlineColor = Color.yellow;
    public float outlineWidth = 0.01f;

    private GameObject outlineObject;

    void Start()
    {
        CreateOutline();
        HideOutline();
    }

    void CreateOutline()
    {
        // 외곽선용 쉘 오브젝트 생성
        outlineObject = new GameObject("Outline");
        outlineObject.transform.SetParent(transform);
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one * (1f + outlineWidth);

        // 외곽선용 메쉬 복사
        MeshFilter sourceMF = GetComponent<MeshFilter>();
        MeshRenderer sourceMR = GetComponent<MeshRenderer>();

        MeshFilter outlineMF = outlineObject.AddComponent<MeshFilter>();
        outlineMF.mesh = sourceMF.mesh;

        MeshRenderer outlineMR = outlineObject.AddComponent<MeshRenderer>();
        Material outlineMat = new Material(Shader.Find("Unlit/Color"));
        outlineMat.color = outlineColor;
        outlineMR.material = outlineMat;

        // 뒷면만 렌더해서 외곽선처럼 보이게 (선택)
        outlineMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineMR.receiveShadows = false;
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
