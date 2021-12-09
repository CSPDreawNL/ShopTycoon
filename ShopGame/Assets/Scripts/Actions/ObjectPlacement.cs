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
            // set the object to be transparent
            Renderer _ghostRend = _ghostObject.GetComponent<Renderer>();
            Color _ghostColor = _ghostRend.material.color;
            _ghostRend.material = SetTransparent(_ghostRend.material);
            _ghostColor.a = manager.ghostObjectTransparancy;
            _ghostRend.material.color = _ghostColor;

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

        Material SetTransparent(Material _mat)
        {
            _mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            _mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            _mat.SetInt("_ZWrite", 0);
            _mat.DisableKeyword("_ALPHATEST_ON");
            _mat.DisableKeyword("_ALPHABLEND_ON");
            _mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
            _mat.renderQueue = 3000;
            return _mat;
        }
    }
}

