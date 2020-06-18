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
        if (collision.CompareTag("Wall_game_finish"))//判断一个object的名称是否是制定的，这里的object是底层的隐形墙壁，碰到就要重开
        {
            transform.position = player.transform.position;//球的位置和玩家的板位置重合
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;//将球的速度减为0
            transform.SetParent(player.transform);//将球的父亲物体设置为玩家的板，这样在移动板子时球也会跟着移动
        }
    }



}
