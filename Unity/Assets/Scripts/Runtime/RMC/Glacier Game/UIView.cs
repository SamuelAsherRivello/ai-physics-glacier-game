using UnityEngine;
using UnityEngine.UIElements;

namespace RMC.GlacierGame
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class UIView : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        //  Fields ----------------------------------------
        [SerializeField]
        private UIDocument _uiDocument;
        private Label _scoreLabel;
        private Label _titleLabel;


        //  Unity Methods ---------------------------------
        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
            
            //AI PROMPT: fetch and store private variables from _uiDocument for #ScoreLabel and #TitleLabel
            _scoreLabel = _uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
            _titleLabel = _uiDocument.rootVisualElement.Q<Label>("TitleLabel");
            
            //AI PROMPT: set titlelabel to value of "Glacier Game" 
            _titleLabel.text = "Glacier Game";
        }


        //  Methods ---------------------------------------
        public void DisplayScore(int value)
        {
            //AI PROMPT: set scorelabel to value of "Score: 000"
            _scoreLabel.text = $"Score: {value:000}";
        }


        //  Event Handlers --------------------------------
        public void Target_OnCompleted(string message)
        {

        }


    }
}