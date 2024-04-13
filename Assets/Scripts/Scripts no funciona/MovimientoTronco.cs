using UnityEngine;

public class MovimientoTronco : MonoBehaviour
{
    /*
    public float m_Speed = 2f;
    private GameObject m_Despawn;

    void Start()
    {
        // Buscar el GameObject con la etiqueta "Despawn" en la escena
        m_Despawn = GameObject.FindWithTag("Despawn");

        // Verificar si se encontró el GameObject
        if (m_Despawn == null)
        {
            Debug.LogError("No se encontró el objeto 'Despawn' en la escena.");
        }
    }

    void Update()
    {
        if (m_Despawn == null)
        {
            return; // Salir de la actualización si no se encontró el objeto 'Despawn'
        }

        Vector3 direction = (m_Despawn.transform.position - transform.position).normalized;
        float distanceToMove = m_Speed * Time.deltaTime;

        // Mueve el objeto hacia el punto objetivo
        transform.Translate(direction * distanceToMove);

        // Si el objeto ha llegado al punto objetivo, reciclarlo
        if (transform.position.x <= m_Despawn.transform.position.x)
        {
            RecycleObject();
        }
    }

    // Método para reciclar el objeto en la pool
    private void RecycleObject()
    {
        // Desactivar el GameObject
        gameObject.SetActive(false);

        // Reciclar el objeto en ObjectPoolTroncos
        ObjectPoolTroncos.instance.RecycleObject(gameObject);
    }
    */
}