using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// trans late Scena if you enadble sub and esc sub you will chage Scean
public class PhotoSubTransScean : MonoBehaviour
{
    // GameManager를 통한 상태 확인
    public GameObject Sub;

    // 전환할 씬 이름
    public string sceneToLoad = "scene_2";

    void Update()
    {
        // Sub가 존재하고, 활성화되어 있으며, ESC 키가 눌렸을 때만 씬 전환
        if (Sub != null && Sub.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("dd");
        }
    }
}
