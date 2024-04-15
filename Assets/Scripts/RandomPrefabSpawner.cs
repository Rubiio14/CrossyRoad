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
        }
    }
}
/*
public List<GameObject> prefabsToSpawn;
public Transform spawnPoint;
public List<GameObject> activeInstances = new List<GameObject>();

RandomPrefabSpawner
public void SpawnRandomPrefab()
{
    // Verificar si hay al menos un prefab en la lista
    if (prefabsToSpawn.Count == 0)
    {
        Debug.LogWarning("No hay prefabs en la lista para spawnear.");
        return;
    }

    // Generar un índice aleatorio dentro del rango de la lista de prefabs
    int randomIndex = Random.Range(0, prefabsToSpawn.Count);

    // Obtener el prefab aleatorio
    GameObject randomPrefab = prefabsToSpawn[randomIndex];

    // Verificar si ya hay una instancia activa del prefab seleccionado
    if (activeInstances.Contains(randomPrefab))
    {
        // Si ya hay una instancia activa, crear una nueva instancia
        GameObject newPrefabInstance = Instantiate(randomPrefab, spawnPoint.position, Quaternion.identity);
        activeInstances.Add(newPrefabInstance);
    }
    else
    {
        // Si no hay una instancia activa, simplemente activarla
        randomPrefab.SetActive(true);
        randomPrefab.transform.position = spawnPoint.position;
        activeInstances.Add(randomPrefab);
    }
}
*/


