using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LGAMES.Config;

namespace LGAMES.WordFight
{
    public class AttackUIHandler : MonoBehaviour
    {

        #region :: Variables
        [SerializeField] private Button attackButton;
        [SerializeField] private Transform attackParent;
        [SerializeField] private List<UILetterTileAttackQue> uiLetterTileAtckQueList = new List<UILetterTileAttackQue>();
        [Header("Class Reference")]
        [SerializeField] private Logger logger;
        [SerializeField] private InGameUIManager inGameUIManager;

        private GameObject uiLetterTileAtckQuePrefab;

        private int minLetterToAttack;
        #endregion

        #region :: Listeners
        public delegate void ListenerOnAttack();
        public event ListenerOnAttack EventOnAttack;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            minLetterToAttack = GameConfig.Min_Letter_Attack;

            uiLetterTileAtckQuePrefab = inGameUIManager.GetUILetterTileAtckQuePrefab();

            InitializeAttack();
        }
        #endregion

        #region :: Properties
        public List<UILetterTileAttackQue> GetLetterUIInAtckBtnList()
        {
            return uiLetterTileAtckQueList;
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
            if (uiLetterTileAtckQueList.Count < minLetterToAttack)
                return false;

            int countLetterCanAttack = 0;

            foreach (UILetterTileAttackQue liab in uiLetterTileAtckQueList)
            {
                if (liab.attack)
                    countLetterCanAttack++;

                if (countLetterCanAttack >= minLetterToAttack)
                    return true;
            }

            return false;
        }

        public void RemoveFromAttackQueue(int letterId)
        {
            foreach (UILetterTileAttackQue ltaq in uiLetterTileAtckQueList)
            {
                if (ltaq.letterProperties.letterId == letterId)
                {
                    ltaq.RemoveFromAttack();
                    InitializeAttack();
                    return;
                }
            }
        }

        public void AddToAttackQueue(LetterProperties letterProperties, UILetterTile uiLetterTile)
        {
            foreach (UILetterTileAttackQue ltaq in uiLetterTileAtckQueList)
            {
                if (ltaq.letterProperties.letterId == letterProperties.letterId)
                {
                    ltaq.AddToAttack();
                    InitializeAttack();
                    return;
                }
            }

            // create letter ui if not already from the list
            GameObject newObj = Instantiate(uiLetterTileAtckQuePrefab, attackParent);
            UILetterTileAttackQue letterTileAtckQue = newObj.GetComponent<UILetterTileAttackQue>();
            letterTileAtckQue.letterProperties = letterProperties;
            letterTileAtckQue.uiLetterTile = uiLetterTile;
            letterTileAtckQue.attackUIHandler = this;
            letterTileAtckQue.Setup();
            letterTileAtckQue.AddToAttack();
            uiLetterTileAtckQueList.Add(letterTileAtckQue);
            InitializeAttack();
        }

        public void InitializeAttack()
        {
            attackButton.interactable = CanAttack();
        }
        #endregion

        #region :: Enumerator 
        IEnumerator WaitSecToGenerateNewLetter()
        {
            yield return new WaitForSeconds(1f);
            inGameUIManager.GetLetterTileInstantiator().SetupLetterUIButton();
            logger.Information("New letters are generated");
            StopCoroutine(WaitSecToGenerateNewLetter());
        }
        #endregion

    }
}