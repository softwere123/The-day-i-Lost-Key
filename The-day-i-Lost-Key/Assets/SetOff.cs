using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOff : MonoBehaviour
{
    public GameObject Off;
    public GameObject on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on.activeSelf)
        {
            Off.SetActive(false);
        }
    }
}
