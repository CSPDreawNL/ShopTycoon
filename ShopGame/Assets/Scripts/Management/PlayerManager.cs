using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Actions;
using UnityEngine.InputSystem;

namespace Game.Management
{
    public class PlayerManager : MonoBehaviour
    {
        [HideInInspector] public Movement movementScript { get; private set; }
        [HideInInspector] public PlayerInteraction interactionScript { get; private set; }

        [HideInInspector] public ControlsManager controls { get; private set; }

        [Header("Movement")]
        public int speedModifier = 1;

        [Header("Interaction")]
        [SerializeField] public float raycastDistance = 3;

        private void Awake()
        {
            controls = new ControlsManager();
            movementScript = GetComponent<Movement>();
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