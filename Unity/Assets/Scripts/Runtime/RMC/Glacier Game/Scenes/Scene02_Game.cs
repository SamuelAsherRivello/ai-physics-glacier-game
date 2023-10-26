using System.Collections.Generic;
using UnityEngine;

namespace RMC.GlacierGame.Scenes
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class Scene02_Game : MonoBehaviour
    {
        //  Consts ----------------------------------------
        public const int PointsPerPenguin = 10;
        public const int MaxPoints = 30;

        //  Properties ------------------------------------
        public int Score 
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                _uiView.DisplayScore(_score);
            }
        }

        //  Fields ----------------------------------------
        [SerializeField]
        private PlayerView _playerView;

        [SerializeField]
        private GlacierView _glacierView;
 
        [SerializeField]
        private WaterView _waterView;
        [SerializeField]
        private UIView _uiView;

        //AI PROMPT: Create serialized field that is a list of PenguinView 
        [SerializeField]
        private List<PenguinView> _penguinViews;
        
        private int _score = 0;
        
        //  Unity Methods ---------------------------------
        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
            
            //AI PROMPT: loop through _penguinViews and subscribe to the one public event OnWaterCollision
            foreach (var penguinView in _penguinViews)
            {
                penguinView.OnWaterCollision.AddListener(OnPenguinView_OnWaterCollision);
            }
            
            _playerView.OnWaterCollision.AddListener(OnPlayerView_OnWaterCollision);

            Score = 0;
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
        private void OnPenguinView_OnWaterCollision(GameObject gameObject)
        {
            PenguinView penguinView = gameObject.GetComponent<PenguinView>();
            if (penguinView != null)
            {
                //AI PROMPT: Destroy the penguinView
                Destroy(penguinView.gameObject);

                Score += PointsPerPenguin;

                if (Score > MaxPoints)
                {
                    Debug.Log("Game Over");
                }
            }
        }
        
        private void OnPlayerView_OnWaterCollision(GameObject gameObject)
        {
            PlayerView playerView = gameObject.GetComponent<PlayerView>();
            if (playerView != null)
            {
                playerView.ResetPosition();
            }
        }
    }
}