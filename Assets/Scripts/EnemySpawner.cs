using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.3f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        foreach (Wave wave in waves) {
            for (int i = 0; i < wave.count; i++) {
                GameObject.Instantiate(wave.enemyProfab, START.position, Quaternion.identity);
                CountEnemyAlive++;

                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }

            // 如果当前敌人不为0, 暂停
            while (CountEnemyAlive > 0) {
                yield return 0;
            }

             yield return new WaitForSeconds(waveRate);
        }
    }
}
