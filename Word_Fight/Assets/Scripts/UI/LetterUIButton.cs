using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LGAMES.WordFight
{
    public class LetterUIButton : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("UI Reference")]
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMP;
        [Header("Letter Value")]
        public int letterId;
        public char letter;
        #endregion

        #region :: Variables

        #endregion

        #region :: Class Reference
        private LetterAttackUIManager letterAttackUIHandler;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            if (letterAttackUIHandler == null)
                letterAttackUIHandler = LetterAttackUIManager.GetInstance();

            textMP.SetText(letter.ToString().ToUpper());

            button.onClick.AddListener(delegate
            {
                OnLetterAction();
            });
        }
        #endregion

        #region :: Properties
        public char GetLetter()
        {
            return letter;
        }
        #endregion

        #region :: Events
        private void OnLetterAction()
        {
            if (letterAttackUIHandler.InAttackQueue(this))
            {
                letterAttackUIHandler.RemoveFromAttackQueue(this);
            }
            else 
            {
                letterAttackUIHandler.CreateLetterAttackUI(this);
            }
        }
        #endregion

        #region :: Methods

        #endregion

    }
}
