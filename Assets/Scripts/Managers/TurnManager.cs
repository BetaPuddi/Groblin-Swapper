using System;
using UnityEngine;

namespace Managers
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager instance;

        public static event Action OnPlayerBeforeTurn;
        public static event Action OnPlayerBeforeAction;
        public static event Action OnPlayerAfterAction;
        public static event Action OnEnemyBeforeTurn;
        public static event Action OnEnemyBeforeAction;
        public static event Action OnEnemyAfterAction;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void OnPlayerTurnBegin()
        {
            OnPlayerBeforeTurn?.Invoke();
            OnPlayerTurn();
        }

        public void OnPlayerTakeAction()
        {
            OnPlayerBeforeAction?.Invoke();
            OnPlayerAfterAction?.Invoke();
        }

        public void OnEnemyTurnBegin()
        {
            OnEnemyBeforeTurn?.Invoke();
            OnEnemyTurn();
        }

        public void OnEnemyTakeAction()
        {
            OnEnemyBeforeAction?.Invoke();
            OnEnemyAfterAction?.Invoke();
        }

        public void OnPlayerTurn()
        {

        }

        public void OnEnemyTurn()
        {

        }
    }
}