using UnityEngine;
using System.Collections.Generic;

namespace LGAMES.WordFight
{
    public class LetterManager
    {

        #region :: Variables
        private readonly char[] letterArray =
                {
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z'
            };
        #endregion

        #region :: Properties
        public char[] GetLetterArray()
        {
            return letterArray;
        }
        #endregion

    }
}
