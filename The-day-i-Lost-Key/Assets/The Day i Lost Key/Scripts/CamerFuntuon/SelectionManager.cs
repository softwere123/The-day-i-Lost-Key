using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable"; // ���� ������ ������Ʈ�� �±�
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial; // �⺻ ����
    
    //�ٽ� ���� ���� ȣ��
    private Transform _selection;

    private void Update()
    {
        //������ ���ǽ�
        if ( _selection != null)
        {
            
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial; // ����: ���� ����
            _selection = null; // ���� ����


        }
        //var  ray�� ī�޶� ��ũ�� ����Ʈ�� ���̷� ��ȯ
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if ���� ����� ����ĳ��Ʈ �Լ� ����
        RaycastHit hit;

        // ���� ĳ��Ʈ Ž���� ���� �ƿ� ���ǹ����� ȣ�⼱��
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if ((selection.CompareTag(selectableTag)))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    // ���õ� ������Ʈ�� ���� ó��
                    selectionRenderer.material = highlightMaterial; // ����: ���� ����
                }

            }

            _selection = selection;

        }
    }
   
}
