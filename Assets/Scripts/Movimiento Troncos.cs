using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTroncos : MonoBehaviour
{
    public Transform[] waypoints;
    public float carSpeed = 5f;

    void Update()
    {
        if (transform.position != waypoints[0].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[0].position, carSpeed * Time.deltaTime);
            // Vector3 waypointLocation = (waypoints[0].position - transform.position).normalized;
        }
        else
        {
            transform.position = waypoints[1].position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("sE HACE HIJO");
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
