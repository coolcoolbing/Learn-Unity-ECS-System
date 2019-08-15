using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于实例化生成正方体的个数
/// </summary>
public class SpawnCubes : MonoBehaviour
{
    public GameObject cube; //预制体
    public int rows;
    public int cols;

    private void Start()
    {
        //生成正方体组成的柏林噪声的地形
        for(int x = 0; x < rows; x++)
        {
            for (int z=0;z<cols; z++)
            {
                GameObject instance = Instantiate(cube);
                //生成的cube的y周是靠柏林噪声随机生成的
                Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x * 0.2f, z * 0.21f), z);
                instance.transform.position = pos;
            }
        }
    }

}
