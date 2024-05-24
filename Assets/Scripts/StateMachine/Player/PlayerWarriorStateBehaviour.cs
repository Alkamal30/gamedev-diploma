using Assets.Scripts.StateMachine;
using Assets.Scripts.StateMachine.Base;
using Assets.Scripts.StateMachine.Player;
using System.Collections.Generic;

public class PlayerWarriorStateBehaviour : BasePlayerStateBehaviour
{
    protected override void InitializeStates(List<BaseState<PlayerStateContext>> statesList)
    {
        base.InitializeStates(statesList);

        statesList.AddRange(new List<BaseState<PlayerStateContext>>
        {
            new PlayerWarriorSingleAttackState(this, Context),
            new PlayerWarriorLongAttackState(this, Context),
        });
    }
}
