using UnityEngine;
using Game.Actions;

namespace Game.Management
{
    [RequireComponent(typeof(Movement), typeof(PlayerInteraction), typeof(Looking))]
    public class PlayerManager : MonoBehaviour
    {
        [HideInInspector] public Movement movementScript { get; private set; }
        [HideInInspector] public PlayerInteraction interactionScript { get; private set; }
        [HideInInspector] public Looking lookingScript { get; private set; }

        [HideInInspector] public ControlsManager controls { get; private set; }

        [Header("Movement Controls")]
        public float moveSpeedModifier = 1;
        public float lookSpeedModifier = 1;

        [Header("Interaction")]
        [SerializeField] public float raycastDistance = 3;

        private void Awake()
        {
            controls = new ControlsManager();

            movementScript = GetComponent<Movement>();
            interactionScript = GetComponent<PlayerInteraction>();
            lookingScript = GetComponent<Looking>();
        }
        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }
    }
}