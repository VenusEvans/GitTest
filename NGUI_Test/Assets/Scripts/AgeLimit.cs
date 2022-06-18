using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//人工校验年龄在18-120岁，如果超出范围默认设置为18或120
public class AgeLimit : MonoBehaviour
{
    UIInput input;

    void Awake()
    {
        input = GetComponent<UIInput>();
    }
    
    public void OnAgeValueChanged()
    {
        string value = input.value;
        int valueInt = int.Parse(value);

        if (valueInt < 18)
        {
            input.value = "18";
        }

        if (valueInt > 120)
        {
            input.value = "120";
        }
    }
}
