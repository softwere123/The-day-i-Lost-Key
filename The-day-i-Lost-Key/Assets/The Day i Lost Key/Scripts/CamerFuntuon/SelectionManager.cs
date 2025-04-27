using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//단일 책임 원칙 각 책임을 가져와 별도의 인터 페이스로 옮겨 선택관리자가 한가지만 책임짐으로 한다
public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable"; // 선택 가능한 오브젝트의 태그
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial; // 기본 재질
 


    private Transform _selection;

    //다시 재질 변경 호출
    private void Update()
    {
        // Deselection/Selection Response
        if (_selection != null)
        {
            var selection = _selection;
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = defaultMaterial;
            }
        }
        #region Raycasting and Selection

        //Creating Ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Selection Determination
        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        #endregion
        // Deselection/Selection Response
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null) 
            {
                selectionRenderer.material = highlightMaterial;
            }
        }

    }

}
