using Unity.VisualScripting;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour
{
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial; // 기본 재질
    private void OnSelect(Transform selection)
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = _selecltionResponse.highlightMaterial;
        }
    }

    private void OnDeselect()
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = _selecltionResponse.defaultMaterial;
        }
    }


}