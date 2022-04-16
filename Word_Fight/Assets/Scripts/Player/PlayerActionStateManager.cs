using UnityEngine;

namespace LGAMES.WordFight
{
    public enum PlayerActionState
    { 
        PREPARING,
        READY,
        ATTACK
    }

    public class PlayerAttackStateManager : MonoBehaviour
    {

        #region :: Variables

        #endregion

        #region :: Class Reference

        #endregion

        #region :: Listeners
        public delegate void ListenerActionState(PlayerActionState actionState);
        public event ListenerActionState EventActionState;
        #endregion

        #region :: Lifecycle

        #endregion

        #region :: Properties

        #endregion

        #region :: Events

        #endregion

        #region :: Methods

        #endregion

        #region :: Enumerator 

        #endregion

    }
}
