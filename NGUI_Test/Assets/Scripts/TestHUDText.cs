using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHUDText : MonoBehaviour
{
    HUDText text;


    void Start()
    {
        text = GetComponent<HUDText>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            text.Add(-10, Color.red, 1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            text.Add(+10, Color.green, 1);
        }
    }
}
