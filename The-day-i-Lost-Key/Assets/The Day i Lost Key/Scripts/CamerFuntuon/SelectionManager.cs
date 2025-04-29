using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//���� å�� ��Ģ �� å���� ������ ������ ���� ���̽��� �Ű� ���ð����ڰ� �Ѱ����� å�������� �Ѵ�
public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable"; // ���� ������ ������Ʈ�� �±�
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial; // �⺻ ����
 


    private Transform _selection;

    //�ٽ� ���� ���� ȣ��
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
