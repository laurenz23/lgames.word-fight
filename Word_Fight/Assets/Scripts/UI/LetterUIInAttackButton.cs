using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LGAMES.WordFight
{
    public class LetterUIInAttackButton : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("UI Reference")]
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMP;
        #endregion

        #region :: Class Reference
        public LetterProperties letterProperties;
        public LetterUIButton letterUIButton;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            button.onClick.AddListener(delegate
            {
                letterUIButton.OnLetterAction();
            });
        }
        #endregion

        #region :: Method
        public void Setup()
        {
            textMP.SetText(letterProperties.letter.ToString().ToUpper());
        }
        #endregion

    }
}
