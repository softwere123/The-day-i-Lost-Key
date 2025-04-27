using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable"; // 선택 가능한 오브젝트의 태그
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial; // 기본 재질
    
    //다시 재질 변경 호출
    private Transform _selection;

    private void Update()
    {
        //변경할 조건식
        if ( _selection != null)
        {
            
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial; // 예시: 색상 변경
            _selection = null; // 선택 해제


        }
        //var  ray에 카메라 스크린 포인트를 레이로 변환
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if 문에 사용할 레이캐스트 함수 선언
        RaycastHit hit;

        // 레이 캐스트 탐색기 제작 아웃 조건문으로 호출선언
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if ((selection.CompareTag(selectableTag)))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    // 선택된 오브젝트에 대한 처리
                    selectionRenderer.material = highlightMaterial; // 예시: 색상 변경
                }

            }

            _selection = selection;

        }
    }
   
}
