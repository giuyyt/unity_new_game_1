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
