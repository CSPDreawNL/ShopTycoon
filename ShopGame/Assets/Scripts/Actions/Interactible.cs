using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    [SerializeField] protected UnityEvent m_onInteract;
    [SerializeField] protected UnityEvent m_onDebug;

    public void Interact()
    {
        m_onInteract.Invoke();
    }

    public void DebugFunction()
    {
        m_onDebug.Invoke();
    }
}
