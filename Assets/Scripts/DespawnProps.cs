using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnProps : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Prop"))
        {
            // Si el objeto que entra en el otro collider es un "prop", añadirlo a la lista de prefabs a spawnear
            RandomPrefabSpawner.instance.inactiveObjects.Add(other.gameObject);
            other.gameObject.SetActive(false);
            other.gameObject.transform.parent = null;
        }
        if(other.CompareTag("Prop1"))
        {
            // Si el objeto que entra en el otro collider es un "prop", añadirlo a la lista de prefabs a spawnear
            other.gameObject.SetActive(false);
            other.gameObject.transform.parent = null;
        }

    }
}
