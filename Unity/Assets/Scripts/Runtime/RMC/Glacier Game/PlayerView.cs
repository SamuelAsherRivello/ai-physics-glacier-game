using UnityEngine;

namespace RMC.MyProject.Scenes
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField]
        private Rigidbody _rigidBody;


        //  Unity Methods ---------------------------------
        private float horizontalInput;
        private float verticalInput;
        public float speed = 5.0f;

        void Start()
        {
        }

        void Update()
        {
            // Collect input from ASDF keys, arrow keys, and gamepad left stick
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

        void FixedUpdate()
        {
            Vector3 force = new Vector3(horizontalInput, 0, verticalInput) * speed;
            _rigidBody.AddForce(force);
        }

        //  Methods ---------------------------------------


        //  Event Handlers --------------------------------
        public void Target_OnCompleted(string message)
        {

        }
    }
}