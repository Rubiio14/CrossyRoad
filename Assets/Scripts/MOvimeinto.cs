using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvimeinto : MonoBehaviour
{
  
    
    
    public void Start()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }


    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }
    

    void MoveTarget(Vector3 m_Direction)
    {
        if (PlayerBehaviour.instance != null && !PlayerBehaviour.instance.m_CanJump)
        {        
          LeanTween.move(gameObject, gameObject.transform.position + new Vector3(0, 0, -m_Direction.normalized.z), 0.25f).setEase(LeanTweenType.easeOutQuad); 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DespawnProp"))
        {
            Debug.Log("Entra");
            NuevoPropsGenerator.instance.RecycleObject(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }

}
