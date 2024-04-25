using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TerrainGeneratorManager : MonoBehaviour
{
    // TerrenoBase
    [SerializeField]
    public GameObject m_InicialTerrainSpawn;
    public GameObject[] m_InicialTerrains;
    public AudioSource[] m_AmbientMusic;
    public PostProcessProfile[] m_PostProcessProfiles;
    public int m_RandomIndex;

    // Pops de 1 salto
    [SerializeField] GameObject[] m_PropsSpawn;
    [SerializeField] GameObject[] m_PropsCesped;
    [SerializeField] GameObject[] m_PropsNieve;
    [SerializeField] GameObject[] m_PropsDesierto;
    [SerializeField] GameObject[] m_PropsCandyLand;
    [SerializeField] GameObject[][] m_TodosLosProps;

    // Post Processing
    public PostProcessVolume m_CustomPostProcessVolume;
    PostProcessVolume m_PostProcessVolume;

    /// <summary>
    /// Genera un Terreno Inicial de una lista al empezar el juego(con todos sus efectos)
    /// </summary>
    void Start()
    {

        // Elige Terreno inicial
        m_RandomIndex = Random.Range(0, m_InicialTerrains.Length);
        m_InicialTerrains[m_RandomIndex].transform.position = m_InicialTerrainSpawn.transform.position;

        // Elige Música según el Terreno inicial
        m_AmbientMusic[m_RandomIndex].transform.position = m_InicialTerrainSpawn.transform.position;
        m_AmbientMusic[m_RandomIndex].Play();

        // Asignar el perfil de postprocesamiento aleatorio al volumen de postprocesamiento específico
        m_CustomPostProcessVolume.profile = m_PostProcessProfiles[m_RandomIndex];

        // Elegir Props correspondientes al terreno inicial
        m_TodosLosProps = new GameObject[][]
        {
            m_PropsCesped,
            m_PropsNieve,
            m_PropsDesierto,
            m_PropsCandyLand
        };

        // Acceder a los props correspondientes al terreno inicial seleccionado aleatoriamente
        GameObject[] m_PropsDelTerrenoInicial = m_TodosLosProps[m_RandomIndex];

        // Seleccionar aleatoriamente 3 objetos del array m_PropsDelTerrenoInicial
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
            propSeleccionado.transform.position = m_PropsSpawn[i].transform.position;
            m_PropsSeleccionados.Add(propSeleccionado);
            m_IndicesUsados.Add(m_RandomIndex);
        }
    }
}