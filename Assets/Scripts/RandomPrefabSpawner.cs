using UnityEngine;
using System.Collections.Generic;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RandomPrefabSpawner : MonoBehaviour
{
    public List<GameObject> objectsList;
    public List<GameObject> inactiveObjects = new List<GameObject>();
    public GameObject activeObject;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject propParent;

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
    private void Start()
    {
        foreach (GameObject prefab in objectsList)
        {
            prefab.SetActive(false);
            inactiveObjects.Add(prefab);
        }

        SpawnRandomPrefab();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == activeObject)
        {
            SpawnRandomPrefab();
        }
    }

    public void SpawnRandomPrefab()
    {
        if (inactiveObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveObjects.Count);

            activeObject = inactiveObjects[randomIndex];
            activeObject.SetActive(true);

            activeObject.transform.position = spawnPoint.transform.position;

            inactiveObjects.RemoveAt(randomIndex);

            activeObject.transform.parent = propParent.transform;

            GameObject m_Coin = activeObject.transform.GetChild(0).gameObject;
            m_Coin.SetActive(true);
        }
    }
}


