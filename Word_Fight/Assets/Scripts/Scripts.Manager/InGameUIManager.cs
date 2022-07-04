using UnityEngine;

namespace LGAMES.WordFight
{

    public class InGameUIManager : MonoBehaviour
    {

        #region :: Variables
        [Header("UI Prefab")]
        [SerializeField] private GameObject uiLetterTilePrefab;
        [SerializeField] private GameObject uiLetterTileAtckQuePrefab;
        [SerializeField] private GameObject skillBtnPrefab;
        #endregion

        #region :: Class Reference
        private static InGameUIManager instance;
        [Header("Class Reference")]
        [SerializeField] private LetterTileInstantiator letterTileInstantiator;
        [SerializeField] private AttackManager attackManager;
        [SerializeField] private AttackUIHandler attackUIHandler;
        #endregion

        #region :: Lifecycle
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion

        #region :: Properties
        public static InGameUIManager GetInstance()
        {
            return instance;
        }

        public GameObject GetUILetterTilePrefab()
        {
            return uiLetterTilePrefab;
        }

        public GameObject GetUILetterTileAtckQuePrefab()
        {
            return uiLetterTileAtckQuePrefab;
        }

        public GameObject GetSkillBtnPrefab()
        {
            return skillBtnPrefab;
        }

        public LetterTileInstantiator GetLetterTileInstantiator()
        {
            return letterTileInstantiator;
        }

        public AttackManager GetAttackManager()
        {
            return attackManager;
        }

        public AttackUIHandler GetAttackUIHandler()
        {
            return attackUIHandler;
        }
        #endregion

    }
}
