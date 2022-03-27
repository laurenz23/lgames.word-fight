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
        private GameObject letterButtonPrefab;
        private List<LetterUIButton> letterList = new List<LetterUIButton>();
        private int letterIDGenerator;
        #endregion

        #region :: Class Reference
        private LetterGeneratorManager letterGeneratorManager;
        [Header("Script Reference")]
        [SerializeField] private UIPrefabManager uiPrefabManager;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            letterGeneratorManager = new LetterGeneratorManager();
        }

        private void Start()
        {
            letterButtonPrefab = uiPrefabManager.letterUIButton;

            while (letterList.Count < numberToInstantiate)
            {
                Transform letterParent = GetAvailableLetterUIParent();

                if (letterParent != null) 
                {
                    CreateLetterButtons(letterParent);
                }
            }
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
        private void CreateLetterButtons(Transform letterParent)
        {
            GameObject newLetter = Instantiate(letterButtonPrefab, letterParent);
            LetterUIButton letterUIButton = newLetter.GetComponent<LetterUIButton>();
            letterUIButton.letterProperties.letterId = letterIDGenerator++;
            letterUIButton.letterProperties.letter = letterGeneratorManager.GetRandomLetter();
            letterList.Add(letterUIButton);
        }
        #endregion

    }
}
