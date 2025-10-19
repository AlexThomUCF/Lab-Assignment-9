using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] prefabList;
    public int waveDelay;
    // Start is called before the first frame update
    void Start()
    {
        prefabList = Resources.LoadAll<GameObject>("EnemyPrefabs");
        StartCoroutine(WaveStart());


    }


   
    // Update is called once per frame

    public void spawnEnemy()
    {

        for (int i = 0; i < 7; i++)
        {
            int tempNumber = Random.Range(0, prefabList.Length);
            GameObject enemyPrefab = prefabList[tempNumber];

            GameObject enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyInstance.transform.localPosition = new Vector3(i * 2f, 3.5f, 0);

            EnemyStats stats = new EnemyStats.Builder()
                 .WithHP(Random.Range(30f, 60f))
                 .WithScore(Random.Range(20, 100))
                 .Build();

            Enemy enemyScript = enemyInstance.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.SetStats(stats);
            }
            else
            {
                Debug.LogWarning($"Enemy prefab '{enemyPrefab.name}' has no Enemy script!");
            }


            enemyInstance.transform.SetParent(transform);

        }



    }

    IEnumerator WaveStart()
    {
        while(true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(waveDelay);
        }

    }
}
