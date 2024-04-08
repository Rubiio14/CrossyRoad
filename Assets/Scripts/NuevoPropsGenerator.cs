using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoPropsGenerator : MonoBehaviour
{
    public static NuevoPropsGenerator instance { get; private set; }

    [System.Serializable]
    public struct PrefabData
    {
        public GameObject m_Prefab;
        public int preloadObjects;
    }

    public PrefabData[] m_PrefabsToPool;

    private Dictionary<int, Queue<GameObject>> prefabDictionary = new Dictionary<int, Queue<GameObject>>();

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

    private void Start()
    {
        PreloadPrefabs();
    }

    private void PreloadPrefabs()
    {
        foreach (PrefabData data in m_PrefabsToPool)
        {
            int id = data.m_Prefab.GetInstanceID();

            if (!prefabDictionary.ContainsKey(id))
            {
                prefabDictionary.Add(id, new Queue<GameObject>());
            }

            for (int i = 0; i < data.preloadObjects; i++)
            {
                GameObject obj = Instantiate(data.m_Prefab);
                obj.SetActive(false);
                prefabDictionary[id].Enqueue(obj);
                Debug.Log("Prefab added to dictionary. ID: " + id + ", Queue count: " + prefabDictionary[id].Count);
            }
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        int id = prefab.GetInstanceID();

        if (prefabDictionary.ContainsKey(id) && prefabDictionary[id].Count > 0)
        {
            GameObject prefabCopy = prefabDictionary[id].Dequeue();
            prefabCopy.SetActive(true);
            return prefabCopy;
        }

        return null;
    }

    public void RecycleObject(GameObject prefabCopy)
    {
        prefabCopy.SetActive(false);

        int id = prefabCopy.GetInstanceID();

        if (!prefabDictionary.ContainsKey(id))
        {
            prefabDictionary.Add(id, new Queue<GameObject>());
        }

        prefabDictionary[id].Enqueue(prefabCopy);
    }
}
