using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Actions
{
    public class ObjectPlacement : MonoBehaviour
    {
        private Management.PlayerManager manager;
        public bool placeGhost = false;
        [SerializeField] GameObject m_GhostToSpawn;
        private void Start()
        {
            manager = GetComponent<Management.PlayerManager>();
        }
        private void Update()
        {
            if (manager.controls.Player.Interact.triggered)
                StartCoroutine(PlaceGhost(m_GhostToSpawn));
        }
        public IEnumerator PlaceGhost(GameObject _obj)
        {
            GameObject _ghostObject = Instantiate(_obj);
            placeGhost = true;
            while (placeGhost)
            {
                RaycastHit _hit;
                Physics.Raycast(manager.gameObject.transform.position, manager.lookingScript.camera.transform.TransformDirection(Vector3.forward), out _hit, manager.raycastDistance, manager.groundMask);
                if (_hit.collider)
                {
                    _ghostObject.transform.position = _hit.point + new Vector3(0,_ghostObject.gameObject.GetComponent<Renderer>().bounds.size.y / 2, 0);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

