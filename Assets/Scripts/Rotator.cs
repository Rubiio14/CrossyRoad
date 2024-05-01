using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float m_Speed;

	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Vector3.forward * m_Speed * Time.deltaTime);
	}
}
