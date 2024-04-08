using JetBrains.Annotations;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private void OnEnable()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }

    private void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }

    private void MoveTarget(Vector3 direction)
    {
        if (PlayerBehaviour.instance != null && !PlayerBehaviour.instance.m_CanJump)
        {
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(0, 0, -direction.normalized.z), 0.25f)
                     .setEase(LeanTweenType.easeOutQuad);
                     
        }
    }

   
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DespawnProp"))
        {
        ObjectPool.Instance.RecycleObject(gameObject);
        }
    }
        
    
}