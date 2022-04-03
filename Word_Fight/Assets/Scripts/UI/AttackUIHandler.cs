using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LGAMES.WordFight
{
    public class AttackUIHandler : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private Button attackButton;
        [SerializeField] private Transform attackParent;
        #endregion

        #region :: Variables
        [SerializeField]
        private List<LetterUIInAttackButton> letterUIInAtckBtnList = new List<LetterUIInAttackButton>();
        private GameObject letterUIInAtckBtnPrefab;
        #endregion

        #region :: Class Reference
        [Header("Class Reference")]
        [SerializeField] private InGameUIManager inGameUIManager;
        #endregion

        #region :: Listeners
        public delegate void ListenerOnAttack();
        public event ListenerOnAttack EventOnAttack;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            letterUIInAtckBtnPrefab = inGameUIManager.GetLetterUIInAtckBtnPrefab();

            InitializeAttack();
        }
        #endregion

        #region :: Properties
        public List<LetterUIInAttackButton> GetLetterUIInAtckBtnList()
        {
            return letterUIInAtckBtnList;
        }
        #endregion

        #region :: Events
        public void OnAttackAction()
        {
            attackButton.interactable = false;
            EventOnAttack?.Invoke();
            StartCoroutine(WaitSecToGenerateNewLetter());
        }
        #endregion

        #region :: Methods
        public bool CanAttack()
        {
            if (letterUIInAtckBtnList.Count < inGameUIManager.GetAttackManager().minLetterForAttack)
                return false;

            int countLetterCanAttack = 0;

            foreach (LetterUIInAttackButton liab in letterUIInAtckBtnList)
            {
                if (liab.attack)
                    countLetterCanAttack++;

                if (countLetterCanAttack >= inGameUIManager.GetAttackManager().minLetterForAttack)
                    return true;
            }

            return false;
        }

        public void RemoveFromAttackQueue(int letterId)
        {
            foreach (LetterUIInAttackButton letterUIAttack in letterUIInAtckBtnList)
            {
                if (letterUIAttack.letterProperties.letterId == letterId)
                {
                    letterUIAttack.RemoveFromAttack();
                    InitializeAttack();
                    return;
                }
            }
        }

        public void AddToAttackQueue(LetterProperties letterProperties, LetterUIButton letterUIButton)
        {
            foreach (LetterUIInAttackButton letterUIAttack in letterUIInAtckBtnList)
            {
                if (letterUIAttack.letterProperties.letterId == letterProperties.letterId)
                {
                    letterUIAttack.AddToAttack();
                    InitializeAttack();
                    return;
                }
            }

            // create letter ui if not already from the list
            GameObject newObj = Instantiate(letterUIInAtckBtnPrefab, attackParent);
            LetterUIInAttackButton letterUIInAttack = newObj.GetComponent<LetterUIInAttackButton>();
            letterUIInAttack.letterProperties = letterProperties;
            letterUIInAttack.letterUIButton = letterUIButton;
            letterUIInAttack.attackUIHandler = this;
            letterUIInAttack.Setup();
            letterUIInAttack.AddToAttack();
            letterUIInAtckBtnList.Add(letterUIInAttack);
            InitializeAttack();
        }

        public void InitializeAttack()
        {
            if (CanAttack())
                attackButton.interactable = true;
            else
                attackButton.interactable = false;
        }
        #endregion

        #region :: Enumerator 
        IEnumerator WaitSecToGenerateNewLetter()
        {
            yield return new WaitForSeconds(1f);
            inGameUIManager.GetInstantiatorLetterUIButton().SetupLetterUIButton();
            StopCoroutine(WaitSecToGenerateNewLetter());
        }
        #endregion

    }
}
