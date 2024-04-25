using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteAgua : MonoBehaviour
{
    /// <summary>
    /// Script que detecta la muerte del jugador cuando entra en contacto con el agua
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Entra");
            GameUI.instance.GameEnding();
            PlayerBehaviour.instance.gameObject.SetActive(false);
            SwipeController.instance.enabled = false;
        }
    }
}
