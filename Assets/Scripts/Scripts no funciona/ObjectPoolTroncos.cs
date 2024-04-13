using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTroncos : MonoBehaviour
{
    // Clase que representa un pool de objetos
    private class ObjectPoolEntry
    {
        public GameObject prefab;
        public List<GameObject> objects = new List<GameObject>();
    }

    // Lista para almacenar múltiples pools de objetos
    private List<ObjectPoolEntry> pools = new List<ObjectPoolEntry>();

    // Singleton para acceder a la instancia desde otros scripts
    public static ObjectPoolTroncos instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para configurar un pool para un prefab específico
    public void SetupPool(GameObject prefab, int initialPoolSize)
    {
        if (!PoolExists(prefab))
        {
            ObjectPoolEntry entry = new ObjectPoolEntry();
            entry.prefab = prefab;

            // Llenar el pool con instancias del prefab
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                entry.objects.Add(obj);
            }

            pools.Add(entry);
        }
        else
        {
            Debug.LogWarning("Pool for prefab " + prefab.name + " already exists.");
        }
    }

    // Método para verificar si un pool ya existe para un prefab específico
    private bool PoolExists(GameObject prefab)
    {
        foreach (ObjectPoolEntry entry in pools)
        {
            if (entry.prefab == prefab)
            {
                return true;
            }
        }
        return false;
    }

    // Método para obtener un objeto del pool
    public GameObject GetObjectFromPool(GameObject prefab)
    {
        ObjectPoolEntry entry = GetPoolEntryForPrefab(prefab);
        if (entry != null && entry.objects.Count > 0)
        {
            GameObject obj = entry.objects[entry.objects.Count - 1];
            entry.objects.RemoveAt(entry.objects.Count - 1);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogWarning("Pool for prefab " + prefab.name + " is empty. Unable to get object.");
            return null;
        }
    }

    // Método para reciclar un objeto en el pool
    public void RecycleObject(GameObject obj)
    {
        ObjectPoolEntry entry = GetPoolEntryForObject(obj);
        if (entry != null)
        {
            obj.SetActive(false);
            entry.objects.Add(obj);
        }
        else
        {
            Debug.LogWarning("Object " + obj.name + " does not belong to any pool. Destroying...");
            Destroy(obj);
        }
    }

    // Método para obtener la entrada del pool para un prefab específico
    private ObjectPoolEntry GetPoolEntryForPrefab(GameObject prefab)
    {
        foreach (ObjectPoolEntry entry in pools)
        {
            if (entry.prefab == prefab)
            {
                return entry;
            }
        }
        return null;
    }

    // Método para obtener la entrada del pool para un objeto específico
    private ObjectPoolEntry GetPoolEntryForObject(GameObject obj)
    {
        foreach (ObjectPoolEntry entry in pools)
        {
            if (entry.objects.Contains(obj))
            {
                return entry;
            }
        }
        return null;
    }
}