using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject prefab;
    public Transform parentTransform;

    private bool m_PlayerMoved = false;
    public int preloadCount = 10;

    void Start()
    {
        // Precargar objetos al inicio del juego
        ObjectPool.Instance.PreloadObjects(prefab, preloadCount, parentTransform);
    }
    void Update()
    {
        if (PlayerBehaviour.instance != null && !m_PlayerMoved && PlayerBehaviour.instance.m_CanJump == false && PlayerBehaviour.instance.m_StepsBack == 0)
        {
            m_PlayerMoved = true;
            SpawnObject();
        }
        else if (PlayerBehaviour.instance != null && m_PlayerMoved && PlayerBehaviour.instance.m_CanJump)
        {
            m_PlayerMoved = false;
        }
    }

    void SpawnObject()
    {
        GameObject obj = ObjectPool.Instance.GetObject(prefab);
        if (obj != null)
        {
          
            obj.transform.position = parentTransform.transform.position;
        }
    }
}