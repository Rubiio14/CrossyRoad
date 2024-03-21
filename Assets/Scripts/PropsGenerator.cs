using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsGenerator : MonoBehaviour
{
    public GameObject m_PropsGeneratorSpawn;
    public GameObject[] m_Props;
    public int m_PropsInPool = 4;

    private static bool propsGenerated = false;

    private void Start()
    {
        if (!propsGenerated)
        {
            foreach (var m_PropsObjects in m_Props)
            {
                ObjectPool.PreLoad(m_PropsObjects, m_PropsInPool);
            }
            propsGenerated = true;
        }
    }

    public GameObject GenerateProps()
    {
        if (!propsGenerated)
        {
            Debug.LogWarning("Props have not been generated yet. Call GenerateProps() after Props have been generated.");
            return null;
        }

        int m_RandomIndex = Random.Range(0, m_Props.Length);
        GameObject propObject = m_Props[m_RandomIndex];
        propObject.transform.position = m_PropsGeneratorSpawn.transform.position;
        return ObjectPool.GetObject(propObject);
    }
}