---
title: unity游戏开发入门笔记_1
date: 2020-06-18 13:07:55
tags: unity游戏开发
categories: 
- unity游戏开发
---
参照了一个十分钟游戏制作挑战的视频：https://www.bilibili.com/video/BV1Ca4y1x7RP

将一些技巧记录在此：

1.Material作用（之一）：可以调整反弹系数，在物体和其发生碰撞并反弹时可以用到


应用的地方：碰撞器
![pic_1](https://gitee.com/giuyyt/hexo_blog_image/raw/master/unity-new-1/1.PNG)

创建的方法：新建Physics Material 2D
![pic_2](https://gitee.com/giuyyt/hexo_blog_image/raw/master/unity-new-1/2.PNG)


2.Canvas:制作UI时使用，直接创建即可，起到类似于底板的作用。然后在它下面创建text之类的元素。

3.Sprite：2D时使用较多。

4.球的脚本Ball：
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ball : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///触发了底层的隐形墙壁，重开
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall_game_finish"))//判断一个object的名称是否是指定的，这里的object是底层的隐形墙壁，碰到就要重开
        {
            transform.position = player.transform.position;//球的位置和玩家的板位置重合
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;//将球的速度减为0
            transform.SetParent(player.transform);//将球的父亲物体设置为玩家的板，这样在移动板子时球也会跟着移动
        }
    }



}
```


5.玩家的板子Player的脚本：
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isStart;//判断游戏此时是否开始
    public float force;//在按下空格时给小球的力
    public float speed;//板子横向移动的速度

    public GameObject ball;//指代小球物体
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// 判断是否开始游戏，若按下空格表示开始游戏，给小球一个初始力使其开始弹射
    /// </summary>
    void Update()
    {
        if (!isStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))//按下空格键
            {
                ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);//给小球力
                transform.DetachChildren();//使得板子的所有子物体脱离自己，这样当板子移动时它们不再跟随
            }

            float horizonalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;//移动速度，向右为正，以秒为单位（而不是帧）

            transform.Translate(Vector2.right * horizonalMove);//让板移动


        }
    }
}

```


