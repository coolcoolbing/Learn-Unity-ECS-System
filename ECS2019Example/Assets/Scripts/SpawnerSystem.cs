using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
public class SpawnerSystem : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreateManager() => m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new SpawnJob
        {
            CommandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer(),

        }.ScheduleSingle(this, inputDeps);
        m_EntityCommandBufferSystem.AddJobHandleForProducer(job);
        return job;
    }

    [Obsolete]
    struct SpawnJob : IJobProcessComponentDataWithEntity<Spawner, LocalToWorld>
    {
        public EntityCommandBuffer CommandBuffer;
        public void Execute(Entity entity,int index, ref Spawner spawner,ref LocalToWorld location)
        {
            //循环生成大量的正方体
            for(int x = 0; x < spawner.Erows; x++)
            {
                for(int z = 0; z < spawner.Ecols; z++)
                {
                    var instance = CommandBuffer.Instantiate(spawner.Prefab);
                    var pos = math.transform(location.Value,new float3(x,noise.cnoise(new float2(x,z)*0.21f),z));
                    CommandBuffer.SetComponent(instance, new Translation{ Value = pos });
                }
            }
            CommandBuffer.DestroyEntity(entity);
        }
    }
    
}
