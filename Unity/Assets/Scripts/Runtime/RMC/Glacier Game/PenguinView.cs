using RMC.GlacierGame.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace RMC.GlacierGame
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// The visual representation and behavior of the Penguin in the game.
    /// </summary>
    public class PenguinView : MonoBehaviour
    {
        //  Events ----------------------------------------
        public WaterCollisionUnityEvent OnWaterCollision = new WaterCollisionUnityEvent();

        //  Fields ----------------------------------------
        [SerializeField]
        private PlayerView _playerView;

        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private Rigidbody _rigidBody;


        //  Unity Methods ---------------------------------
        protected void Update()
        {
            RotateTowardsPlayer();
            MoveTowardsPlayer();
        }


        //  Methods ---------------------------------------
        private void RotateTowardsPlayer()
        {
            Vector3 directionToPlayer = _playerView.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        private void MoveTowardsPlayer()
        {
            Vector3 forceDirection = (_playerView.transform.position - transform.position).normalized;
            _rigidBody.AddForce(forceDirection * _moveSpeed);
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
