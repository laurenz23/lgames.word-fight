using UnityEngine;

namespace LGAMES.WordFight
{
    public class InGameUIManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("UI Prefab")]
        [SerializeField] private GameObject letterUIBtnPrefab;
        [SerializeField] private GameObject letterUIInAtckBtnPrefab;
        [SerializeField] private GameObject skillBtnPrefab;
        #endregion

        #region :: Variables

        #endregion

        #region :: Class Reference
        private static InGameUIManager instance;
        [Header("Class Reference")]
        [SerializeField] private InstantiatorLetterUIButton instantiatorLetterUIButton;
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

        public GameObject GetLetterUIBtnPrefab()
        {
            return letterUIBtnPrefab;
        }

        public GameObject GetLetterUIInAtckBtnPrefab()
        {
            return letterUIInAtckBtnPrefab;
        }

        public GameObject GetSkillBtnPrefab()
        {
            return skillBtnPrefab;
        }

        public InstantiatorLetterUIButton GetInstantiatorLetterUIButton()
        {
            return instantiatorLetterUIButton;
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
