//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
//using Unity.VisualScripting;
//using UnityEditor;
//using UnityEngine;
////code summation : while pracacties single-Responsibility principle  end yet

//// two tpye of default and highlight share one by one will make much easier to manage
////단일 책임 원칙 각 책임을 가져와 별도의 인터 페이스로 옮겨 선택관리자가 한가지만 책임짐으로 한다
//public class SelectionManager : MonoBehaviour
//{
//    [SerializeField] private string selectableTag = "Selectable"; // 선택 가능한 오브젝트의 태그
//    [SerializeField] private Material highlightMaterial;
//    [SerializeField] private Material defaultMaterial; // 기본 재질

//    private HighlightSelectionResponse _selecltionResponse;

//    private Transform _selection;

//    //다시 재질 변경 호출
//    private void Update()
//    {
//        // Deselection/Selection Response
//        if (_selection != null)
//        {
          
//            _selecltionResponse.OnDeselect(_selection);
//            //컨트롤 . 으로 함수 간소화 
//        }
//        #region Raycasting and Selection
//        //이거 왜 28저거 가독성 하나로 저렇게 토글화?

//        //Creating Ray
//        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//        // Selection Determination
//        _selection = null;
//        if (Physics.Raycast(ray, out var hit))
//        {
//            var selection = hit.transform;
//            if (selection.CompareTag(selectableTag))
//            {
//                _selection = selection;
//            }
//        }

//        #endregion
//        // Deselection/Selection Response
//        if (_selection != null)
//        {

//            _selecltionResponse.OnSelect(_selection);
//            //Extra method 사용하여 기존 코드에서 클래스를 분리화 하여 옮길수 있게 하였다
//        }

//    }

  

  
//}
//internal class HighlightSelectionResponse : MonoBehaviour
//{
//    [SerializeField] public Material highlightMaterial;
//    [SerializeField] public Material defaultMaterial; // 기본 재질
//    private void OnSelect(Transform selection)
//    {
//        var selectionRenderer = _selection.GetComponent<Renderer>();
//        if (selectionRenderer != null)
//        {
//            selectionRenderer.material = _selecltionResponse.highlightMaterial;
//        }
//    }

//    private void OnDeselect()
//    {
//        var selectionRenderer = _selection.GetComponent<Renderer>();
//        if (selectionRenderer != null)
//        {
//            selectionRenderer.material = _selecltionResponse.defaultMaterial;
//        }
//    }


//}