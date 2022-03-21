using UnityEngine;
using System.Collections.Generic;

namespace LGAMES.WordFight
{
    public class LetterAttackUIManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private Transform attackParent;
        #endregion

        #region :: Variables
        private List<LetterUIButton> letterPreparedAttack = new List<LetterUIButton>();
        private List<LetterUIButton> letterHideFromPanel = new List<LetterUIButton>();
        #endregion

        #region :: Class Reference
        private static LetterAttackUIManager instance;
        #endregion

        #region :: Listeners

        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion

        #region :: Properties
        public static LetterAttackUIManager GetInstance()
        {
            return instance;
        }

        public bool InAttackQueue(LetterUIButton letterUIButton)
        {
            foreach (LetterUIButton luib in letterPreparedAttack)
            {
                if (luib.letterId == letterUIButton.letterId)
                    return true;
            }

            return false;
        }
        #endregion

        #region :: Events

        #endregion

        #region :: Methods
        public void CreateLetterAttackUI(LetterUIButton letterUIButton)
        {
            Instantiate(letterUIButton.gameObject, attackParent);
            letterPreparedAttack.Add(letterUIButton);
            AddToHideFromPanel(letterUIButton);
        }

        public void RemoveFromAttackQueue(LetterUIButton letterUIButton)
        {
            foreach (LetterUIButton luib in letterHideFromPanel)
            {
                if (luib.letterId == letterUIButton.letterId)
                {
                    luib.gameObject.SetActive(true);
                    letterHideFromPanel.Remove(luib);
                    letterPreparedAttack.Remove(luib);
                    Destroy(letterUIButton.gameObject);
                    return;
                }
            }
        }

        private void AddToHideFromPanel(LetterUIButton letterUIButton)
        {
            letterHideFromPanel.Add(letterUIButton);
            letterUIButton.gameObject.SetActive(false);
        }
        #endregion

    }
}
