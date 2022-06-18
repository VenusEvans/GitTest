using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour
{
    //存储所有的格子
    public GameObject[] grids;

    //存储物品名称
    public string[] clothesName;

    //存储物品
    public GameObject clothes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Pickup();
        }
    }

    //捡起物品
    public void Pickup()
    {
        //随机生成数组里面的物品
        int index = Random.Range(0, clothesName.Length);
        string name = clothesName[index];

        bool isFind = false;

        for (int i = 0; i < grids.Length; i++)
        {
            //判断当前格子里有没有物品
            if (grids[i].transform.childCount > 0)
            {
                //如果有 判断当前游戏物体的名字
                MyDragAndDropItem item = grids[i].GetComponentInChildren<MyDragAndDropItem>();
                //判断当前游戏物品的名字 跟我们捡到的游戏物体名字是否一样
                if (item.sprite.spriteName == name)
                {
                    isFind = true;
                    item.AddCount(1);
                    break;
                }
            }
        }
        if (isFind == false) //如果没有找到相同的执行以下代码
        {
            for (int i = 0; i < grids.Length; i++)
            {
                if (grids[i].transform.childCount == 0)
                {
                    //如果第i个格子里没有物品
                    //添加我们捡起来的物品
                    GameObject go = NGUITools.AddChild(grids[i], clothes);
                    go.GetComponent<UISprite>().spriteName = name;
                    go.transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }
       
    }
}
