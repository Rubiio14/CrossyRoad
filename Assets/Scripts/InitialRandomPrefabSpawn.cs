using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRandomPrefabSpawner : MonoBehaviour
{
    //Listas
    public List<GameObject> m_InitialobjectsList;
    public List<GameObject> m_InitialinactiveObjects = new List<GameObject>();
    public GameObject m_ActiveObject;

    //Objeto activo
    [SerializeField] GameObject m_SpawnPoint;
    [SerializeField] GameObject m_PropParent;

    //Contador de props iniciales
    private int m_PropsActivated = 0;
    //Spawn de objetos medianos y grandes
    public GameObject m_MiddleSpawnPoint;

    /// <summary>
    /// En el start desactiva los Objetos de m_ObjectsList y los mete en m_InactiveObjects
    /// </summary>
    private void Start()
    {
        foreach (GameObject prefab in m_InitialobjectsList)
        {
            prefab.SetActive(false);
            m_InitialinactiveObjects.Add(prefab);
        }

        SpawnRandomPrefab();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_ActiveObject)
        {
            SpawnRandomPrefab();
        }
    }
    /// <summary>
    /// Método que spawnea un prefab random de la lista de m_InitialinactiveObjects lo elimina de la lista si el contador
    /// llega a 6 se desactiva este Spawn y se activa el de obstaculos medianos y grandes
    /// </summary>
    public void SpawnRandomPrefab()
    {
        if (m_PropsActivated < 7 && m_PropsActivated > 5)
        {
            this.enabled = false;
            m_MiddleSpawnPoint.SetActive(true);
        }
        else
        {
            if (m_InitialinactiveObjects.Count > 0)
            {
                int randomIndex = Random.Range(0, m_InitialinactiveObjects.Count);

                m_ActiveObject = m_InitialinactiveObjects[randomIndex];
                m_ActiveObject.SetActive(true);

                m_ActiveObject.transform.position = m_SpawnPoint.transform.position;

                m_InitialinactiveObjects.RemoveAt(randomIndex);

                m_ActiveObject.transform.parent = m_PropParent.transform;

                m_PropsActivated++;
            }

        }

    }
}
