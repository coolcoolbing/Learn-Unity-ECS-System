using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using UnityEngine;

[RequiresEntityConversion]
public class PerlinPositionProxy : MonoBehaviour,IConvertGameObjectToEntity
{
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new PerlinPositionComponent{ };    //创建组件
        dstManager.AddComponentData(entity, data);  //将组件添加到实体中
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
