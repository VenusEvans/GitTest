using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //冷却时间
    public float coldTime = 2;

    public bool startCold = false;

    UISprite sprite;

    void Awake()
    {
        //查找冷却图片所在的位置
        sprite = transform.Find("Sprite").GetComponent<UISprite>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !startCold)
        {
            Debug.Log("按下了A键");
            sprite.fillAmount = 1;
            startCold = true;
        }

        if (startCold)
        {
            sprite.fillAmount -= (1f / coldTime) * Time.deltaTime;
            if(sprite.fillAmount <= 0.05f)
            {
                startCold = false;
                sprite.fillAmount = 0;
            }
        }
    }
}
