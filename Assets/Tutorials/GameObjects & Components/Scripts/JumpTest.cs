using UnityEngine;

namespace DapperDino.GettingStarted.GameObjectsAndComponents
{
    public class JumpTest : MonoBehaviour
    {
        public Rigidbody rb;
        public float jumpForce;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}
