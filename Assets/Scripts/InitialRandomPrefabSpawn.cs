using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialRandomPrefabSpawner : MonoBehaviour
{
    public List<GameObject> InitialobjectsList;
    public List<GameObject> InitialinactiveObjects = new List<GameObject>();
    public GameObject activeObject;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject propParent;

    private int propsActivated = 0;

    public GameObject m_MiddleSpawnPoint;

    private void Start()
    {
        foreach (GameObject prefab in InitialobjectsList)
        {
            prefab.SetActive(false);
            InitialinactiveObjects.Add(prefab);
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
        if (propsActivated < 7 && propsActivated > 5)
        {
            this.enabled = false;
            m_MiddleSpawnPoint.SetActive(true);
        }
        else
        {
            if (InitialinactiveObjects.Count > 0)
            {
                int randomIndex = Random.Range(0, InitialinactiveObjects.Count);

                activeObject = InitialinactiveObjects[randomIndex];
                activeObject.SetActive(true);

                activeObject.transform.position = spawnPoint.transform.position;

                InitialinactiveObjects.RemoveAt(randomIndex);

                activeObject.transform.parent = propParent.transform;

                propsActivated++;
            }

        }

    }
}
