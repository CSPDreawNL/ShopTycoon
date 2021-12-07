using UnityEngine;

namespace Game.Actions
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] Management.PlayerManager manager;

        [SerializeField] GameObject camera;
        private void Update()
        {
            // check input and either interact or debug interact
            if (manager.controls.Player.Interact.triggered)
                Debug.Log("INTERACTING");
            //Interact();
            if (manager.controls.Player.DebugInteract.triggered)
                Debug.Log("DEBUGGING");
            //Interact(true);
        }
        public void Interact(bool _debug = false)
        {
            // shoot a raycast and check if it hits anything
            RaycastHit _whatHit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * manager.raycastDistance, out _whatHit);
            if (_whatHit.transform != null)
                CheckForInteraction(_whatHit, _debug);
        }

        void CheckForInteraction(RaycastHit _hit, bool _debug = false)
        {
            // if the object hit can be interacted with
            var _interactible = _hit.transform.GetComponent<Interactible>();
            if (_interactible)
            {
                // interact or debug interact
                if (!_debug)
                    _interactible.Interact();
                else if (_debug)
                    _interactible.DebugFunction();
            }
        }
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            // draw a ray from the camera, forwards
            Debug.DrawRay(camera.transform.position, transform.TransformDirection(Vector3.forward) * manager.raycastDistance, Color.red);
        }
#endif
    }
}