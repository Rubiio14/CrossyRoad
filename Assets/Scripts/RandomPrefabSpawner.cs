using UnityEngine;
using System.Collections.Generic;


public class RandomPrefabSpawner : MonoBehaviour
{
    //Listas
    public List<GameObject> m_ObjectsList;
    public List<GameObject> m_InactiveObjects = new List<GameObject>();
    //Objeto activo
    public GameObject m_ActiveObject;
    //Spawn y GameObject de movimiento de Prefabs
    [SerializeField] GameObject m_SpawnPoint;
    [SerializeField] GameObject m_PropParent;  

    //Singleton
    public static RandomPrefabSpawner instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    /// <summary>
    /// En el start desactiva los Objetos de m_ObjectsList y los mete en m_InactiveObjects
    /// </summary>
    private void Start()
    {
        foreach (GameObject prefab in m_ObjectsList)
        {
            prefab.SetActive(false);
            m_InactiveObjects.Add(prefab);
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
    /// Método que spawnea un prefab random de la lista de m_InactiveObjects lo elimina de la lista si el prefab contiene una moneda
    /// la activa, de ese modo las monedas se reciclan
    /// </summary>
    public void SpawnRandomPrefab()
    {
        if (m_InactiveObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, m_InactiveObjects.Count);

            m_ActiveObject = m_InactiveObjects[randomIndex];
            m_ActiveObject.SetActive(true);

            m_ActiveObject.transform.position = m_SpawnPoint.transform.position;

            m_InactiveObjects.RemoveAt(randomIndex);

            m_ActiveObject.transform.parent = m_PropParent.transform;

            GameObject m_Coin = m_ActiveObject.transform.GetChild(0).gameObject;
            m_Coin.SetActive(true);
        }
    }
}


