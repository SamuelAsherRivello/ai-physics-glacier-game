using RMC.GlacierGame.Events;
using UnityEngine;

namespace RMC.GlacierGame
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        //  Events ----------------------------------------
        public WaterCollisionUnityEvent OnWaterCollision = new WaterCollisionUnityEvent();


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        [SerializeField]
        private Rigidbody _rigidBody;
        private Vector3 _originalPosition;

        //  Unity Methods ---------------------------------
        private float horizontalInput;
        private float verticalInput;
        public float speed = 5.0f;

        protected void Start()
        {
            StorePosition();
        }

        protected void Update()
        {
            // Collect input from ASDF keys, arrow keys, and gamepad left stick
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            
        }

        protected void FixedUpdate()
        {
            Vector3 force = new Vector3(horizontalInput, 0, verticalInput) * speed;
            _rigidBody.AddForce(force);
        }

        //  Methods ---------------------------------------
        private void StorePosition()
        {
            _originalPosition = transform.position;
        }
        
        
        public void ResetPosition()
        {
            transform.position = _originalPosition;
            transform.rotation = Quaternion.identity;
            
            _rigidBody.ResetInertiaTensor();
            _rigidBody.ResetCenterOfMass();
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
        }

        
        //  Event Handlers --------------------------------
        // AI PROMPT: Detect collision and if its with a type WaterView then dispatch a UnityEvent called OnWaterCollision
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<WaterView>() != null)
            {
                OnWaterCollision.Invoke(gameObject);
            }
        }
    }
}