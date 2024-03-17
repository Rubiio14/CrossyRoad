using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{

    public GameObject m_EnemyPrefab;
    public float m_SpawnInterval = 2f;
    public int m_MaxEnemies = 10;
    public Transform[] m_SpawnPoints;
    

    private float m_Timer = 0f; 


    private void Awake()
    {
        ObjectPool.PreLoad(m_EnemyPrefab, m_MaxEnemies);
    }
    private void Update()
    {
        
        m_Timer += Time.deltaTime;

        
        if (m_Timer >= m_SpawnInterval)
        {
            SpawnEnemy();
            m_Timer = 0f; 
        }
    }

    private void SpawnEnemy()
    {
        
        Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)]; 
        GameObject enemy = ObjectPool.GetObject(m_EnemyPrefab);      
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = spawnPoint.rotation;
        enemy.SetActive(true);
       
    }

    public void RecycleEnemy(GameObject enemy)
    {
 
        ObjectPool.RecycleObject(m_EnemyPrefab, enemy);
    }

}

/*
public GameObject m_EnemyPrefab;
public int m_Nenemies;

public float m_CarSpeed;
public bool m_IsOnCamera;

void Awake()
{
    ObjectPool.PreLoad(m_EnemyPrefab, m_Nenemies);    
}

public void CarsGenerator()
{
    GameObject m_Enemy = ObjectPool.GetObject(m_EnemyPrefab);
    m_Enemy.transform.position = transform.position;
    Vector3 direction = m_EnemyPrefab.transform.right * -1;

    ///Apply Bullet Speed
    m_Enemy.GetComponent<Rigidbody>().velocity = direction * m_CarSpeed;

}

public void RecycleCars(GameObject m_Enemy)
{
    // Reciclar el terreno utilizando el ObjectPool
    ObjectPool.RecycleObject(m_EnemyPrefab, m_Enemy);
}
*/
