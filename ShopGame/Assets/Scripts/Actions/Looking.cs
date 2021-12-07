using UnityEngine;

namespace Game.Actions
{
    public class Looking : MonoBehaviour
    {
        private Management.PlayerManager manager;

        GameObject camera;
        private void Start()
        {
            manager = GetComponent<Management.PlayerManager>();

            foreach (Transform item in transform)
            {
                if (item.GetComponent<Camera>())
                {
                    camera = item.gameObject;
                    break;
                }    
            }
        }
        private void Update()
        {
            Vector2 _Input = manager.controls.Player.Look.ReadValue<Vector2>();
            camera.transform.rotation *= new Quaternion(_Input.x * Time.deltaTime * manager.lookSpeedModifier, 0, _Input.y * Time.deltaTime * manager.lookSpeedModifier, 0);
        }
    }
}
