using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextListControl : MonoBehaviour
{
    UITextList textList;
    int lineNumber;

    void Awake()
    {
        textList = GetComponent<UITextList>();
    }


    void Update()
    {
        //如果按下鼠标左键，打印文本
        if (Input.GetMouseButtonDown(0))
        {
            textList.Add("Venus Test : " + lineNumber++);
        }
    }
}
