using System.Collections;
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
        private Vector2 letterSize = Vector2.zero;
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
            StartCoroutine(SetTileSize());
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
            UILetterTile uiLetterTile = newLetter.GetComponent<UILetterTile>();
            uiLetterTile.transform.SetAsFirstSibling();
            uiLetterTile.letterProperties.letterId = letterIDGenerator++;
            uiLetterTile.letterProperties.letter = letterGeneratorManager.GetRandomLetter();
            uiLetterTileList.Add(uiLetterTile);

            if (letterSize != Vector2.zero) 
            {
                uiLetterTile.GetComponent<RectTransform>().sizeDelta = letterSize;
            }
        }
        #endregion

        #region Enumerator  
        public IEnumerator SetTileSize() {
            yield return new WaitForEndOfFrame(); 
            
            letterSize = uiLetterTileList[0].GetComponent<RectTransform>().sizeDelta;

            foreach (Transform t in letterUIParentList)
            {
                VerticalLayoutGroup verticalLayout = t.GetComponent<VerticalLayoutGroup>();
                verticalLayout.childControlWidth = false;
                verticalLayout.childControlHeight = false;
            }

            foreach (UILetterTile ult in uiLetterTileList) 
            {
                ult.GetComponent<RectTransform>().sizeDelta = letterSize;
            }
        }
        #endregion

    }
}
