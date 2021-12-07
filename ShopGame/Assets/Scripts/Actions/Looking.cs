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
            // left and right are done on the player, up and down on the camera
            transform.localEulerAngles += new Vector3(0, _Input.x * Time.deltaTime * manager.lookSpeedModifier, 0);
            camera.transform.localEulerAngles += new Vector3(-_Input.y * Time.deltaTime * manager.lookSpeedModifier, 0, 0);
        }
    }
}
