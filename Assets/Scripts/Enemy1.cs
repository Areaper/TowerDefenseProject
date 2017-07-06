using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public float s = 10;
    private Transform[] positions;
    private int index = 0;

    void Start()
    {
        positions = WayPoints.positions;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (index > positions.Length - 1) return;

        // 移动
        transform.Translate((positions[index].position - transform.position).normalized
                            * Time.deltaTime * s);

        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }

		// 判断到达终点
		if (index == positions.Length)
		{
			ReachDestination();
		}
	}

    void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }
}
