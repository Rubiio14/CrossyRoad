using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteAgua : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entra");
            GameUI.instance.GameEnding();
            PlayerBehaviour.instance.gameObject.SetActive(false);
            SwipeController.instance.enabled = false;
        }
    }
}
