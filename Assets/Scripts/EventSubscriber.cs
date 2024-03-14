using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
	public EventCreator eventoEnter;

	public void OnEnable()
	{
		eventoEnter.OnPresionaEnter += HaPresionadoEnter;
	}
	public void OnDisable()
	{
		eventoEnter.OnPresionaEnter -= HaPresionadoEnter;
	}

	private void HaPresionadoEnter()
	{
		Debug.Log("´Presionó Enter");
	}
}
