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
        private readonly List<LetterUIInAttackButton> letterUIInAttackButtonList = new List<LetterUIInAttackButton>();
        private GameObject letterButtonPrefab;
        #endregion

        #region :: Class Reference
        [SerializeField] private UIPrefabManager uiPrefabManager;
        private static LetterAttackUIManager instance;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            letterButtonPrefab = uiPrefabManager.letterUIInAttackButton;
        }
        #endregion

        #region :: Properties
        public static LetterAttackUIManager GetInstance()
        {
            return instance;
        }
        #endregion

        #region :: Methods
        public void CreateLetterAttackUI(LetterProperties letterProperties, LetterUIButton letterUIButton)
        {
            foreach (LetterUIInAttackButton letterUIAttack in letterUIInAttackButtonList)
            {
                if (letterUIAttack.letterProperties.letterId == letterProperties.letterId)
                {
                    letterUIAttack.gameObject.SetActive(true);
                    return;
                }
            }

            GameObject newObj = Instantiate(letterButtonPrefab, attackParent);
            LetterUIInAttackButton letterUIInAttack = newObj.GetComponent<LetterUIInAttackButton>();
            letterUIInAttack.letterProperties = letterProperties;
            letterUIInAttack.letterUIButton = letterUIButton;
            letterUIInAttack.Setup();
            letterUIInAttackButtonList.Add(letterUIInAttack);
        }

        public void RemoveFromAttackQueue(int letterId)
        {
            foreach (LetterUIInAttackButton letterUIAttack in letterUIInAttackButtonList)
            {
                if (letterUIAttack.letterProperties.letterId == letterId)
                {
                    letterUIAttack.gameObject.SetActive(false);
                    return;
                }
            }
        }
        #endregion

    }
}
