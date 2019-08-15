using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Mathematics; //引入命名空间
using Unity.Transforms;
using Unity.Entities;

/// <summary>
/// 系统。需要继承ComponentSystem,并实现这个抽象类
/// </summary>
public class RotationCubeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //遍历所有实体ForEach的参数为委托。可以使用lamda表达式
        //使用这个方法来遍历更新所有“实体”中的组件即component
        Entities.ForEach((ref RotationCubeComponent rotationSpeed,ref Rotation rotation)=> 
        {
            //将旋转的值做一个乘法
            //1.将rotation.Value归一化normalize
            //2.绕math，up即y轴旋转角度
            //3.做一个相乘即改变了旋转的角度
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(),rotationSpeed.speed*Time.deltaTime));
        }
        );  
    }

}
