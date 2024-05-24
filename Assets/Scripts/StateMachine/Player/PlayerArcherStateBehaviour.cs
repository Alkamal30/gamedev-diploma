using Assets.Scripts.StateMachine.Base;
using System.Collections.Generic;

namespace Assets.Scripts.StateMachine.Player
{
    public class PlayerArcherStateBehaviour : BasePlayerStateBehaviour
    {
        protected override void InitializeStates(List<BaseState<PlayerStateContext>> statesList)
        {
            base.InitializeStates(statesList);

            statesList.AddRange(new List<BasePlayerState>
            {
                new PlayerJerkState(this, Context),
                new PlayerArcherAttackState(this, Context),
            });
        }
    }
}
