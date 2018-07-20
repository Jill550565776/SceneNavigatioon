using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Enemy : MonoBehaviour
{
    private new Transform transform;
    //private Player player; // 主角
    //private GameObject player;
    private UnityEngine.AI.NavMeshAgent agent; // 寻路组件
    private float moveSpeed = 1.5f; // 移动速度
    private float rotateSpeed = 30; // 角色旋转速度
    private float timer = 2; // 计时器
    private int life = 15; // 生命值

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();

        // 获取主角
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //player = InteractionSystem.Player;
        
        // 获取寻路组件
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // 指定寻路器的行走速度
        agent.speed = moveSpeed;
        // 设置寻路目标
        //agent.SetDestination(player.hmdTransforms);
    }


    //Use this for target
    private void RotateTo()
    {
        // 获取目标方向
        //Vector3 targetDirection = player.transform.position - transform.position;
        // 计算旋转角度
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward,
        //targetDirection, rotateSpeed * Time.deltaTime, 0);
        // 旋转至新方向
        //transform.rotation = Quaternion.LookRotation(newDirection);
    }



    // Update is called once per frame
    void Update()
    {
    }

    public void OnDamage(int damage)
    {
    }
}
