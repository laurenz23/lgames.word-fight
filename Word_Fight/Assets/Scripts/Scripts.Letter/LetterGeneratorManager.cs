using UnityEngine;

namespace LGAMES.WordFight
{
    public class LetterGeneratorManager
    {

        #region :: Class Reference
        private readonly LetterManager letterManager = new LetterManager();
        #endregion

        #region :: Properties
        public char GetRandomLetter()
        {
            int randomInt = Random.Range(0, 26);
            return letterManager.GetLetterArray()[randomInt];
        }
        #endregion

        #region :: Methods

        #endregion

    }
}
