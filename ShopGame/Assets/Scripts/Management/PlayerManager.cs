using UnityEngine;
using Game.Actions;

namespace Game.Management
{
    [RequireComponent(typeof(Movement), typeof(PlayerInteraction), typeof(Looking))]
    [RequireComponent(typeof(ObjectPlacement))]
    public class PlayerManager : MonoBehaviour
    {
        [HideInInspector] public Movement movementScript { get; private set; }
        [HideInInspector] public PlayerInteraction interactionScript { get; private set; }
        [HideInInspector] public Looking lookingScript { get; private set; }
        [HideInInspector] public ObjectPlacement placementScript { get; private set; }

        [HideInInspector] public ControlsManager controls { get; private set; }

        [Header("Movement Controls")]
        public float moveSpeedModifier = 1;
        public float lookSpeedModifier = 1;

        [Header("Interaction")]
        public float raycastDistance = 3;
        public float objectPlacementDistance = 20;

        [Header("Layer settings")]
        [SerializeField] string groundMaskName = "Ground";
        [HideInInspector] public LayerMask groundMask;

        private void Awake()
        {
            controls = new ControlsManager();

            movementScript = GetComponent<Movement>();
            interactionScript = GetComponent<PlayerInteraction>();
            lookingScript = GetComponent<Looking>();
            placementScript = GetComponent<ObjectPlacement>();

            // set up all the layermasks
            groundMask = LayerMask.NameToLayer(groundMaskName);
        }
        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        //private void OnDrawGizmos()
        //{
        //    // is in here to make prevent issues

        //    // draw a ray from the camera, forwards
        //    Debug.DrawRay(lookingScript.camera.transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.red);

        //    // draw a ray for ghosts
        //    if ()
        //}
    }
}