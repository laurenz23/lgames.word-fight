using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LGAMES.WordFight
{
    public class LetterUIButton : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("UI Reference")]
        [SerializeField] private Image defaultBackground;
        [SerializeField] private Image selectedBackground;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMP;
        [Header("Letter Value")]
        public LetterProperties letterProperties;
        public bool selected;
        #endregion

        #region :: Variables

        #endregion

        #region :: Class Reference
        private LetterAttackUIManager letterAttackUIManager;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            if (letterAttackUIManager == null)
                letterAttackUIManager = LetterAttackUIManager.GetInstance();

            textMP.SetText(letterProperties.letter.ToString().ToUpper());

            button.onClick.AddListener(delegate
            {
                OnLetterAction();
            });

            SetBackground();
        }
        #endregion

        #region :: Properties
        public char GetLetter()
        {
            return letterProperties.letter;
        }
        #endregion

        #region :: Events
        public void OnLetterAction()
        {
            // remove from attack in queue
            if (selected) 
            {
                selected = false;
                letterAttackUIManager.RemoveFromAttackQueue(letterProperties.letterId);
            }
            // proceed to attack in queue
            else
            {
                selected = true;
                letterAttackUIManager.CreateLetterAttackUI(letterProperties, this);
            }

            SetBackground();
        }
        #endregion

        #region :: Methods
        private void SetBackground()
        {
            defaultBackground.gameObject.SetActive(!selected);
            selectedBackground.gameObject.SetActive(selected);
        }
        #endregion

    }
}
