using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ObjectPool");
                    instance = obj.AddComponent<ObjectPool>();
                }
            }
            return instance;
        }
    }

    private Dictionary<int, Queue<GameObject>> objectDictionary = new Dictionary<int, Queue<GameObject>>();

    private ObjectPool() { }

    public void PreloadObjects(GameObject prefab, int count, Transform parentTransform)
    {
        int id = prefab.GetInstanceID();

        if (!objectDictionary.ContainsKey(id))
        {
            objectDictionary.Add(id, new Queue<GameObject>());
        }

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab, parentTransform);
            obj.SetActive(false);
            objectDictionary[id].Enqueue(obj);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        int id = prefab.GetInstanceID();

        if (objectDictionary.ContainsKey(id) && objectDictionary[id].Count > 0)
        {
            GameObject obj = objectDictionary[id].Dequeue();
            obj.SetActive(true);
            return obj;
        }

        Debug.LogWarning("Object pool ran out of objects! Consider increasing the preload count.");
        return null;
    }

    public void RecycleObject(GameObject obj)
    {
        obj.SetActive(false);

        int id = obj.GetInstanceID();

        if (!objectDictionary.ContainsKey(id))
        {
            objectDictionary.Add(id, new Queue<GameObject>());
        }

        objectDictionary[id].Enqueue(obj);
    }
}