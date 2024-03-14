using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : MonoBehaviour
{
    public delegate void PresionaEnter();
    public event PresionaEnter OnPresionaEnter;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            if(OnPresionaEnter != null)
            {
                OnPresionaEnter();
            }
        }
    }
}
