using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities; //引入ecs的命名空间

public class RotationCubeSystem : ComponentSystem//继承抽象类，必须实现抽象类的方法
{
    /// <summary>
    /// 定义一个结构体
    /// </summary>
    struct Group
    {
        public RotationCubeComponent rotation;
        public Transform transform;
    }
    /// <summary>
    /// 实现抽象类的方法onupdate
    /// </summary>
    protected override void OnUpdate()
    {
        //2018版本获得所有entities实体，这个实体含有group里面所定义的组件
        //get
        foreach (var en in GetEntities<Group>())
        {
            //调用这个实体的方法
            en.transform.Rotate(Vector3.down, en.rotation.speed * Time.deltaTime);
        }
    }
}
