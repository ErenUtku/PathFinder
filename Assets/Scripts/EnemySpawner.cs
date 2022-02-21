using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemiesSFX;
    int score;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }
    
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemiesSFX);

            score++;
            spawnedEnemies.text = score.ToString();

            Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
    void Update()
    {
        
    }
}
