using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTroncos: MonoBehaviour
{
    public static ObjectPoolTroncos instance;

    private Queue<GameObject> _objectPool = new Queue<GameObject>();
    public Queue<GameObject> ObjectPool { get { return _objectPool; } }

    public GameObject m_PrefabTronco;
    public GameObject m_Despawn_Point;

    public int m_PoolSize = 10;

    

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

        GameObject m_ObjectPool = this.gameObject;
    }

    void Start()
    {
        SetupPool();
    }

    void SetupPool()
    {
        for (int i = 0; i < m_PoolSize; i++)
        {
            GameObject obj = Instantiate(m_PrefabTronco, transform.position, Quaternion.identity);
            obj.SetActive(false);
            _objectPool.Enqueue(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        if (_objectPool.Count > 0)
        {
            GameObject obj = _objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
       
        GameObject newObj = Instantiate(m_PrefabTronco, transform.position, Quaternion.identity);
        return newObj;
    }

    public void RecycleObject(GameObject obj)
    {
        obj.SetActive(false);
        _objectPool.Enqueue(obj);
    }
}