using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Actions
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody m_Rigid;
        [SerializeField] int m_SpeedModifier;


        private ControlsManager controlsManager;

        private void Awake()
        {
            controlsManager = new ControlsManager();
        }

        private void OnEnable()
        {
            controlsManager.Enable();
        }

        private void OnDisable()
        {
            controlsManager.Disable();
        }

        void Start()
        {
            m_Rigid = GetComponent<Rigidbody>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            //Vector3 _Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        private void Update()
        {
            Vector2 _Input = controlsManager.Player.Move.ReadValue<Vector2>();
            m_Rigid.position += new Vector3(_Input.x, 0, _Input.y) * Time.deltaTime * m_SpeedModifier;
            ;
        }

    }
}
