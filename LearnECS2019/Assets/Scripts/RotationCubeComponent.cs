/*
 * 2019ECS框架学习
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities; //引入命名空间


/// <summary>
/// 实体的组件是一个结构体。需要继承IComponentData接口
/// </summary>
public struct RotationCubeComponent :IComponentData
{
    public float speed; //定义实体旋转的速度
}
