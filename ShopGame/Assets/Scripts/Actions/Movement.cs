using UnityEngine;

namespace Game.Actions
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody m_Rigid;

        private Management.PlayerManager manager;

        void Start()
        {
            manager = GetComponent<Management.PlayerManager>();
            m_Rigid = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector2 _Input = manager.controls.Player.Move.ReadValue<Vector2>();
            m_Rigid.position += new Vector3(_Input.x, 0, _Input.y) * Time.deltaTime * manager.speedModifier;
        }
    }
}
