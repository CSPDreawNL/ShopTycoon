using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] KeyCode m_interactionKey = KeyCode.E;
    [SerializeField] KeyCode m_debugKey = KeyCode.F1;
    [SerializeField] float m_raycastDistance = 3;
    private void Update()
    {
        if (Input.GetKeyDown(m_interactionKey))
            Interact();
        if (Input.GetKeyDown(m_debugKey))
            Interact(true);
    }
    public void Interact(bool _debug = false)
    {
        RaycastHit _whatHit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * m_raycastDistance, out _whatHit);
        if (_whatHit.transform != null)
            CheckForInteraction(_whatHit, _debug);
    }

    void CheckForInteraction(RaycastHit _hit, bool _debug = false)
    {
        var _interactible = _hit.transform.GetComponent<Interactible>();
        if (_interactible)
        {
            if (!_debug)
                _interactible.Interact();
            else if (_debug)
                _interactible.DebugFunction();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * m_raycastDistance, Color.red);
    }
#endif
}
