/*
 * 
 * 实体管理器ECS。所属类型：“混合ECS”开发模式
 * 
 */

using UnityEngine;
using Unity.Entities;

[RequiresEntityConversion]
public class EntitiesManager :MonoBehaviour, IConvertGameObjectToEntity //接口IConvertGameObjectToEntity将gameObject转换成实体Entity
{
    public float FloCubeSpeed=10f;
    /// <summary>
    /// 将gameObject转换成实体Entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="dstManager"></param>
    /// <param name="conversionSystem"></param>
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //创建一个组件
        var data = new RotationCubeComponent { speed = FloCubeSpeed };
        //组件加入到EntityManager中，让unity内置的环境实体管理器进行管理
        dstManager.AddComponentData(entity,data);
    }

}
