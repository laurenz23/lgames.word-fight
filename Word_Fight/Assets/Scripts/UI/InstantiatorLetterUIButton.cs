using UnityEngine;
using System.Collections.Generic;

namespace LGAMES.WordFight
{
    public class InstantiatorLetterUIButton : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private Transform letterUIParent;
        [SerializeField] private List<Transform> letterUIParentList;
        [SerializeField] private int numberToInstantiate = 20;
        [SerializeField] private int maxLetterPerHorParent = 4;
        #endregion

        #region :: Variables
        private GameObject letterBtnPrefab;
        public List<LetterUIButton> letterList = new List<LetterUIButton>();
        private int letterIDGenerator;
        #endregion

        #region :: Class Reference
        private LetterGeneratorManager letterGeneratorManager;
        [Header("Script Reference")]
        [SerializeField] private InGameUIManager inGameUIManager;
        #endregion

        #region :: Listeners

        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            letterGeneratorManager = new LetterGeneratorManager();
        }

        private void Start()
        {
            letterBtnPrefab = inGameUIManager.GetLetterUIBtnPrefab();

            SetupLetterUIButton();
        }
        #endregion

        #region :: Properties
        public List<LetterUIButton> GetLetterList()
        {
            return letterList;
        }

        public Transform GetAvailableLetterUIParent() 
        {
            foreach (Transform t in letterUIParentList)
            {
                if (t.childCount < maxLetterPerHorParent)
                    return t;
            }

            return null;
        }
        #endregion

        #region :: Events

        #endregion

        #region :: Methods
        public void SetupLetterUIButton()
        {
            while (letterList.Count < numberToInstantiate)
            {
                Transform letterParent = GetAvailableLetterUIParent();

                if (letterParent != null)
                {
                    CreateLetterButtons(letterParent);
                }
            }
        }

        private void CreateLetterButtons(Transform letterParent)
        {
            GameObject newLetter = Instantiate(letterBtnPrefab, letterParent);
            LetterUIButton letterUIButton = newLetter.GetComponent<LetterUIButton>();
            letterUIButton.transform.SetAsFirstSibling();
            letterUIButton.letterProperties.letterId = letterIDGenerator++;
            letterUIButton.letterProperties.letter = letterGeneratorManager.GetRandomLetter();
            letterList.Add(letterUIButton);
        }
        #endregion

    }
}
