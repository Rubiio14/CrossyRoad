using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevaCinta : MonoBehaviour
{
    public List<GameObject> objetos = new List<GameObject>(8);
    private bool m_PlayerMoved = false;
    public GameObject spawnpoint;

    void Update()
    {
        // Verifica si el jugador existe y no se ha movido todavía, y si el jugador no puede saltar y no ha retrocedido
        if (PlayerBehaviour.instance != null && !m_PlayerMoved && !PlayerBehaviour.instance.m_CanJump && PlayerBehaviour.instance.m_StepsBack == 0)
        {
            m_PlayerMoved = true; // Marca que el jugador se ha movido

            // Obtiene un índice aleatorio dentro del rango de la lista de objetos
            int randomIndex = Random.Range(0, objetos.Count);
            GameObject randomObject = objetos[randomIndex];
            randomObject.SetActive(true);
            randomObject.transform.position = spawnpoint.transform.position;

            // Verifica si el índice aleatorio es válido
            /*
            if (randomIndex >= 0 && randomIndex < objetos.Count)
            {
                // Activa el objeto aleatorio correspondiente al índice obtenido
                GameObject randomObject = objetos[randomIndex];
                randomObject.SetActive(true);
                randomObject.transform.position = spawnpoint.transform.position;
            }
            else
            {
                Debug.LogWarning("Índice aleatorio fuera de rango.");
            }
            */
        }
        // Si el jugador se ha movido y puede saltar, restablece el indicador de movimiento del jugador
        else if (PlayerBehaviour.instance != null && m_PlayerMoved && PlayerBehaviour.instance.m_CanJump)
        {
            m_PlayerMoved = false;
        }
    }

}