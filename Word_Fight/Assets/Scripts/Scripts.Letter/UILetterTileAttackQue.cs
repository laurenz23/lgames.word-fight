using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LGAMES.WordFight
{
    public class UILetterTileAttackQue : MonoBehaviour
    {

        #region :: Variables
        [Header("UI Reference")]
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMP;
        [Header("Properties")]
        public bool attack;
        #endregion

        #region :: Class Reference
        public LetterProperties letterProperties;
        public UILetterTile uiLetterTile;
        public AttackUIHandler attackUIHandler;
        #endregion

        #region :: Lifecycle
        private void OnDisable()
        {
            attackUIHandler.EventOnAttack -= OnAttack;
        }

        private void Start()
        {
            button.onClick.AddListener(delegate
            {
                uiLetterTile.OnLetterAction();
            });
        }
        #endregion

        #region :: Method
        public void Setup()
        {
            textMP.SetText(letterProperties.letter.ToString().ToUpper());
        }

        public void AddToAttack()
        {
            attack = true;
            gameObject.SetActive(true);
            attackUIHandler.EventOnAttack += OnAttack;
        }

        public void RemoveFromAttack()
        {
            attack = false;
            gameObject.SetActive(false);
            attackUIHandler.EventOnAttack -= OnAttack;
        }

        private void OnAttack()
        {
            attackUIHandler.GetLetterUIInAtckBtnList().Remove(this);
            Destroy(gameObject);
        }
        #endregion

    }
}
