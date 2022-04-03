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
        private InGameUIManager inGameUIManager;
        private AttackUIHandler attackUIHandler;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            if (inGameUIManager == null)
                inGameUIManager = InGameUIManager.GetInstance();

            attackUIHandler = inGameUIManager.GetAttackUIHandler();
        }

        private void OnDisable()
        {
            attackUIHandler.EventOnAttack -= OnAttack;
        }

        private void Start()
        {
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
                attackUIHandler.EventOnAttack -= OnAttack;
                attackUIHandler.RemoveFromAttackQueue(letterProperties.letterId);
            }
            // proceed to attack in queue
            else
            {
                selected = true;
                attackUIHandler.EventOnAttack += OnAttack;
                attackUIHandler.AddToAttackQueue(letterProperties, this);
            }

            SetBackground();
        }

        private void OnAttack()
        {
            inGameUIManager.GetInstantiatorLetterUIButton().GetLetterList().Remove(this);
            Destroy(gameObject);
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
