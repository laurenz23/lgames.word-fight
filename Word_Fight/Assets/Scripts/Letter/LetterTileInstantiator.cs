using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LGAMES.WordFight
{
    public class LetterTileInstantiator : MonoBehaviour
    {

        #region :: Variables
        [SerializeField] private Transform letterUIParent;
        [SerializeField] private List<Transform> letterUIParentList;
        [SerializeField] private int numberToInstantiate = 20;
        [SerializeField] private int maxLetterPerHorParent = 4;

        private GameObject uiLetterTileObj;
        public List<UILetterTile> uiLetterTileList = new List<UILetterTile>();
        private int letterIDGenerator;
        #endregion

        #region :: Class Reference
        private LetterGeneratorManager letterGeneratorManager;
        [Header("Script Reference")]
        [SerializeField] private InGameUIManager inGameUIManager;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            letterGeneratorManager = new LetterGeneratorManager();
        }

        private void Start()
        {
            uiLetterTileObj = inGameUIManager.GetUILetterTilePrefab();

            SetupLetterUIButton();
        }
        #endregion

        #region :: Properties
        public List<UILetterTile> GetLetterList()
        {
            return uiLetterTileList;
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
            while (uiLetterTileList.Count < numberToInstantiate)
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
            GameObject newLetter = Instantiate(uiLetterTileObj, letterParent);
            UILetterTile uiletterTile = newLetter.GetComponent<UILetterTile>();
            uiletterTile.transform.SetAsFirstSibling();
            uiletterTile.letterProperties.letterId = letterIDGenerator++;
            uiletterTile.letterProperties.letter = letterGeneratorManager.GetRandomLetter();
            uiLetterTileList.Add(uiletterTile);
        }
        #endregion

    }
}
