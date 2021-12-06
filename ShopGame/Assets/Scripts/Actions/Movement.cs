using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Actions
{
    public class Movement : MonoBehaviour
    {
        Rigidbody m_Rigid;

        void Start()
        {
            m_Rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 _Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            
        }
    }
}
