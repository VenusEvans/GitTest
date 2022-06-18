using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//我们需要UIDragDropItem这个脚本内的所有方法
//来实现拖拽功能，所以我们继承他
//这样监视面板添加的UIDragDropItem脚本可以删除了
//删除后发现功能依旧完好
public class MyDragAndDropItem : UIDragDropItem
{
    public UISprite sprite;
    public UILabel label;
    public int count = 1;

    public void AddCount(int number = 1)
    {
        count += number;
        label.text = count + "";
    }


    //OnDragDropRelease方法指的是当我们拖拽结束释放后会相应的事件
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        //print(surface);
        //surface代指我们释放到了哪个游戏物体
        //当我们拖拽放置时，会发现输出的为UI Root（老师的是Null，大同小异）
        //此时为了监听我们的格子，我们要把三个格子分别添加上box collider

        //添加好后，会发现Console控制台输出的就是格子的名字了


        ////查看格子内是否有物体
        ////拖拽进去后输出1
        ////print(surface.transform.childCount);
        //if (surface.transform.childCount > 0)
        //{
        //    //如果格子内有东西，交换物品

        //    //如果格子里没有物品的话，输出格子的名。如果有物品，输出的则是物品名
        //    //print(surface);
        //}
        //else
        //{
        //    //没有正常添加

        //    //我所在父类的位置 = 格子的位置
        //    this.transform.parent = surface.transform;

        //    //我所在的本地坐标位置（相对于格子） = 中心点（0，0，0）
        //    this.transform.localPosition = Vector3.zero;
        //}

        //上述思路改变 ↓
        //如果格子里没有物品的话，输出格子的名。如果有物品，输出的则是物品名
        //print(surface);
        // ↑ 根据这个，我们为格子添加标签，来判断格子内是否有东西
        if (surface.tag == "grid")
        {
            //如果标签是grid，证明格子里没有东西，可以放入

            //我所在父类的位置 = 格子的位置
            this.transform.parent = surface.transform;

            //我所在的本地坐标位置（相对于格子） = 中心点（0，0，0）
            this.transform.localPosition = Vector3.zero;
        }
        else if(surface.tag == "clothes")
        {
            //否则如果是物品标签的话，我们要交换他们的位置

            //获得另一个物品的位置
            Transform parent = surface.transform.parent;

            //让另一个物品的位置跑到我们当前这个物品的位置
            surface.transform.parent = this.transform.parent;

            //并且归0
            surface.transform.localPosition = Vector3.zero;

            //让我们要移动的物品跑到它的位置上
            this.transform.parent = parent;

            //让我们自己的位置在归0，居中
            this.transform.localPosition = Vector3.zero;
        }
    }
}
