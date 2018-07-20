using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class cllick : MonoBehaviour {
    //射击属性
    public LayerMask layer; // 射击时射线能射到的碰撞层
    public Transform fx; // 射中目标后的粒子效果
    public AudioClip clip;  // 射击音效

    private Transform muzzlePoint; // 枪口的Transform组件
    private float shootTimer = 0; // 射击间隔的计时器
    private int life = 15; // 生命值

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    private Valve.VR.InteractionSystem.Hand hand;

    void Start()
    {
        hand = gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>();
        // 获取枪口
        muzzlePoint = cameraTransform.FindChild("Hand1/M16/weapon/muzzlepoint").GetComponent<Transform>();
    }

    void Update()
    {
        if (hand.controller == null) return;

        // Change the ButtonMask to access other inputs
        if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Trigger down");
        }

        if (hand.controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Trigger still down");
            shootTimer = 0.1f;
            // 播放射击音效
            GetComponent<AudioSource>().PlayOneShot(clip);
            // 更新UI，减少弹药数量


            GameManager.Instance.SetAmmo(1);
            // 用一个RaycastHit对象保存射线的碰撞结果
            Debug.Log("Trigger Clicked2!");
            RaycastHit info;
            // 从枪口所在位置向摄像机面向的正前方发出一条射线
            // 该射线只与layer指定的层发生碰撞
            if (Physics.Raycast(muzzlePoint.position,
                cameraTransform.TransformDirection(Vector3.forward),
                out info, 100, layer))
            {
                // 判断是否射中Tag为enemy的物体
                if (info.transform.tag.Equals("enemy"))
                {
                    // 敌人减少生命
                    info.transform.GetComponent<Enemy>().OnDamage(1);
                }
            }
            // 在射中的地方释放一个粒子效果
            Instantiate(fx, info.point, info.transform.rotation);
        }

        if (hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Trigger released");
        }
    }


}
