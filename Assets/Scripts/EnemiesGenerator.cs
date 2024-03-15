using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    public GameObject m_EnemyPrefab;
    public int m_Nenemies;
    public float m_CarsDelay;

    void Start()
    {
        ObjectPool.PreLoad(m_EnemyPrefab, m_Nenemies);
    }

    Void Update()
    {
        StartCoroutine(CarsGeneratorDelay(m_CarsDelay));
    }
    
   
    void CarsGenerator()
    {
        GameObject m_Enemy = ObjectPool.GetObject(m_EnemyPrefab);
        m_Enemy.transform.position = gameObject.transform.position

    }
    IEnumerator CarsGeneratorDelay(float time)
    {

        yield return new WaitForSeconds(time);
        CarsGenerator();

    }
}
