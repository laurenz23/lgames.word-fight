using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.WordFight
{
    [AddComponentMenu("LGames/Tools/Logger")]
    public class Logger : MonoBehaviour
    {

        [Header("Settings")]
        public bool _showLog;

        private static Logger instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public static Logger GetInstance()
        {
            return instance;
        }

        public void Information(object message, Object context)
        {
            if (_showLog)
                Debug.Log($"<color=#00BDFE> {message} </color>", context);
        }

        public void Warning(object message, Object context)
        {
            if (_showLog)
                Debug.Log($"<color=#FFFF00> {message} </color>", context);
        }

        public void Error(object message, Object context)
        {
            if (_showLog)
                Debug.Log($"<color=#FF0000> {message} </color>", context);
        }
            
    }
}
