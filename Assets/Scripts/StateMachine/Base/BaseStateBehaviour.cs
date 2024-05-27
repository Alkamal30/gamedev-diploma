using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.StateMachine.Base
{
    public abstract class BaseStateBehaviour<TContext> : MonoBehaviour, IStateSwitcher<TContext>
        where TContext : StateContext
    {
        private BaseState<TContext> _currentState;
        private List<BaseState<TContext>> _supportedStates;

        public void SwitchState<TState>() where TState : BaseState<TContext>
        {
            BaseState<TContext> newState = _supportedStates.FirstOrDefault(x => x is TState)
                ?? throw new NotSupportedException("State is not supported by this State Machine");

            _currentState?.Stop();
            newState.Start();

            _currentState = newState;
        }

        protected BaseState<TContext> CurrentState => _currentState;

        protected abstract void InitializeStates(List<BaseState<TContext>> statesList);

        private void Awake()
        {
            _supportedStates = new List<BaseState<TContext>>();

            InitializeStates(_supportedStates);
        }

        private void Update()
        {
            _currentState?.Update();
        }
    }
}
