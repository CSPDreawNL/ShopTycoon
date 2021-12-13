using UnityEngine;

namespace Game.Actions
{
    public class Movement : MonoBehaviour
    {
        private Management.PlayerManager manager;
        private CharacterController characterController;

        private float m_Gravity = -9.81f;
        private Vector3 m_Velocity;

        [SerializeField] Transform m_GroundCheck;
        private float m_GroundDistance = 0.4f;
        private bool m_IsGrounded;
        [SerializeField] private float m_JumpHeight = 3f;

        void Start()
        {
            manager = GetComponent<Management.PlayerManager>();
            characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            m_IsGrounded = Physics.CheckSphere(m_GroundCheck.position, m_GroundDistance, manager.groundMask);

            if (m_IsGrounded && m_Velocity.y < 0)
            {
                m_Velocity.y = -2f;
            }

            Vector2 _Input = manager.controls.Player.Move.ReadValue<Vector2>();
            Vector3 move = transform.right * _Input.x + transform.forward * _Input.y;
            characterController.Move(move * Time.deltaTime * manager.moveSpeedModifier);

            m_Velocity.y += m_Gravity * Time.deltaTime;
            characterController.Move(m_Velocity * Time.deltaTime);
        }

        private void Update()
        {
            if (m_IsGrounded && manager.controls.Player.Jump.triggered)
            {
                m_Velocity.y = Mathf.Sqrt(m_JumpHeight * -2f * m_Gravity);
            }
        }

    }
}
