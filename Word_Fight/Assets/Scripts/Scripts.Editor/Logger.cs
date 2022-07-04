using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.WordFight
{
    [AddComponentMenu("LGames/Logger")]
    public class Logger : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] private bool _showLog = true;

        public void Information(object message, Object context = null)
        {
            if (_showLog)
                Debug.Log($"<color=#00BDFE>{message}</color>", context);
        }

        public void Warning(object message, Object context = null)
        {
            if (_showLog)
                Debug.Log($"<color=#FFFF00> {message} </color>", context);
        }

        public void Error(object message, Object context = null)
        {
            if (_showLog)
                Debug.Log($"<color=#FF0000> {message} </color>", context);
        }
            
    }
}
