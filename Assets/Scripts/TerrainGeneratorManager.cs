using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorManager : MonoBehaviour
{
    //TerrenoBase
    [SerializeField]
    public GameObject m_InicialTerrainSpawn;
    public GameObject[] m_InicialTerrains;
    public int m_RandomIndex;
    //Pops de 1 salto
    [SerializeField] GameObject[] m_PropsSpawn;
    [SerializeField] GameObject[] m_PropsCesped;
    [SerializeField] GameObject[] m_PropsNieve;
    [SerializeField] GameObject[] m_PropsDesierto;
    [SerializeField] GameObject[] m_PropsCandyLand;
    [SerializeField] GameObject[][] m_TodosLosProps;
    
    

    //Genera un terreno inicial de una lista al empezar el juego en el spawn que se le pase
    void Start()
    {
        // Elige Terreno inicial
        m_RandomIndex = Random.Range(0, m_InicialTerrains.Length);
        m_InicialTerrains[m_RandomIndex].transform.position = m_InicialTerrainSpawn.transform.position;

        // Elegir Props correspondientes al terreno inicial
        m_TodosLosProps = new GameObject[][]
        {
        m_PropsCesped,
        m_PropsNieve,
        m_PropsDesierto,
        m_PropsCandyLand
        };

        // Accede a los props correspondientes al terreno inicial seleccionado aleatoriamente
        GameObject[] m_PropsDelTerrenoInicial = m_TodosLosProps[m_RandomIndex];

        // Selecciona aleatoriamente 3 objetos del array m_PropsDelTerrenoInicial
        List<GameObject> m_PropsSeleccionados = new List<GameObject>();
        List<int> m_IndicesUsados = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int m_RandomIndex;
            do
            {
                m_RandomIndex = Random.Range(0, m_PropsDelTerrenoInicial.Length);
            } while (m_IndicesUsados.Contains(m_RandomIndex));

            GameObject propSeleccionado = m_PropsDelTerrenoInicial[m_RandomIndex];
            propSeleccionado.SetActive(true);
            propSeleccionado.transform.position = m_PropsSpawn[i].transform.position; // Posiciona el objeto en el punto de spawn correspondiente.
            m_PropsSeleccionados.Add(propSeleccionado);
            m_IndicesUsados.Add(m_RandomIndex);
        }

    }
}