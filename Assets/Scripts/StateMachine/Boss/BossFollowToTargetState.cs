﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Boss
{
    public class BossFollowToTargetState : BaseBossState
    {
        public BossFollowToTargetState(IStateSwitcher<BossStateContext> stateSwitcher, BossStateContext context)
            : base(stateSwitcher, context)
        {
        }

        private bool _reachedCheckAvailable;

        public override void Start()
        {
            base.Start();

            _reachedCheckAvailable = false;
            Context.AIDestinationSetter.target = Context.Target;
            Context.StartCoroutine(MakeReachedCheckAvailable());
        }

        public override void Stop()
        {
            base.Stop();

            Context.AIDestinationSetter.target = null;
        }

        public override void Update()
        {
            base.Update();

            if (IsEnemyLeaveAggressionArea())
            {
                StateSwitcher.SwitchState<BossFollowToOriginState>();
                return;
            }
        }

        private bool IsEnemyLeaveAggressionArea()
        {
            return Context.Target == null
                || Vector2.Distance(Context.transform.position, Context.OriginPosition) > Context.FinishAggressionRadius;
        }

        private IEnumerator MakeReachedCheckAvailable()
        {
            yield return null;

            _reachedCheckAvailable = true;
        }
    }
}