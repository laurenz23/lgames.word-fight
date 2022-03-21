using UnityEngine;
using System.Collections.Generic;

namespace LGAMES.WordFight
{
    public class InstantiatorLetterUIButton : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private GameObject letterButtonPrefab;
        [SerializeField] private Transform letterUIParent;
        [SerializeField] private int numberToInstantiate = 20;
        #endregion

        #region :: Variables
        private List<LetterUIButton> letterList = new List<LetterUIButton>();
        private int letterIDGenerator;
        #endregion

        #region :: Class Reference
        private LetterGeneratorManager letterGeneratorManager;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            letterGeneratorManager = new LetterGeneratorManager();
        }

        private void Start()
        {
            while (letterList.Count < numberToInstantiate)
            {
                CreateLetterButtons();
            }
        }
        #endregion

        #region :: Properties
        public List<LetterUIButton> GetLetterList()
        {
            return letterList;
        }
        #endregion

        #region :: Events

        #endregion

        #region :: Methods
        private void CreateLetterButtons()
        {
            GameObject newLetter = Instantiate(letterButtonPrefab, letterUIParent);
            LetterUIButton letterUIButton = newLetter.GetComponent<LetterUIButton>();
            letterUIButton.letterId = letterIDGenerator++;
            letterUIButton.letter = letterGeneratorManager.GetRandomLetter();
            letterList.Add(letterUIButton);
        }
        #endregion

    }
}
