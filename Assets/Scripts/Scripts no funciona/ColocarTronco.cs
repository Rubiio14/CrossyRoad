using System.Collections;
using UnityEngine;

public class ColocarTronco : MonoBehaviour
{
    public GameObject m_prefab;
    public GameObject m_InitialSpawn;

    private void Start()
    {
        ObjectPoolTroncos.instance.SetupPool(m_prefab, 10);
        StartCoroutine(SpawnTroncosRepeatedly());
    }

    IEnumerator SpawnTroncosRepeatedly()
    {
        while (true)
        {
            GameObject tronco = ObjectPoolTroncos.instance.GetObjectFromPool(m_prefab);
            if (tronco != null)
            {
                tronco.SetActive(true);
                tronco.transform.position = m_InitialSpawn.transform.position;
                // Pausa durante 2 segundos antes de obtener otro objeto del pool
                yield return new WaitForSeconds(2f);
            }
            else
            {
                // Pausa durante 1 segundo si no se pudo obtener un objeto del pool
                yield return new WaitForSeconds(1f);
            }
        }
    }
}