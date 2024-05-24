using Assets.Scripts.StateMachine.Base;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Player
{
    public abstract class BasePlayerStateBehaviour : BaseStateBehaviour<PlayerStateContext>
    {
        [SerializeField] private PlayerStateContext _context;

        protected new BasePlayerState CurrentState => base.CurrentState as BasePlayerState;

        protected PlayerStateContext Context => _context;

        public void Attack()
        {
            CurrentState.Attack();
        }

        public void Dead()
        {
            CurrentState.Dead();
        }

        protected override void InitializeStates(List<BaseState<PlayerStateContext>> statesList)
        {
            statesList.AddRange(new List<BasePlayerState>
            {
                new PlayerIdleState(this, Context),
                new PlayerDeadState(this, Context),
                new PlayerMovementState(this, Context),
                new PlayerJerkState(this, Context),
            });

            SwitchState<PlayerIdleState>();
        }
    }
}
