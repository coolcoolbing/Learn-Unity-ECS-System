using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// ECS方法生成成千上万个物体
/// </summary>
public class PerlinProxy : MonoBehaviour,IDeclareReferencedPrefabs,IConvertGameObjectToEntity
{
    public GameObject cube;//预制体
    public int rows;
    public int cols;

    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new Spawner
        {
            Prefab = conversionSystem.GetPrimaryEntity(cube),
            Erows = rows,
            Ecols = cols
        };

        dstManager.AddComponentData(entity, spawnerData);
    }

    void IDeclareReferencedPrefabs.DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(cube);   //添加预制体
    }

}
