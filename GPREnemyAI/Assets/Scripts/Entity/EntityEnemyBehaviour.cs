using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnemyBehaviour : EntityEnemy
{
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="_value"></param>
    /// <returns></returns>
    public Vector3 RotateToDirection(Vector3 _value)
    {
        return (Quaternion.Euler(_value) * transform.forward);
    }

    //-------------------------
    //-----State functions-----
    //-------------------------

    #region State Functions
    public override void StateDefault()
    {
        if (entityHealthStateCurrent == EntityHealthStates.Dead)
            SetCurrentState(AIState.Dead);
    }

    public override void StateIdle()
    {
        if (entityHealthStateCurrent == EntityHealthStates.Dead)
            return;

        if (targetCurrentRange < enemyAttackRange)
            SetCurrentState(AIState.Attacking);
        else
            SetCurrentState(AIState.Following);
    }

    public override void StateAlerted()
    {

    }

    public override void StateSearching()
    {

    }

    public override void StateFollowing()
    {
        if (entityHealthStateCurrent == EntityHealthStates.Dead)
            return;

        if (aiMoveTo.MoveTo(targetObject.transform.position, moveSpeed, targetRangeToAttack))// * 0.6f  
            SetCurrentState(AIState.Attacking);
    }

    public override void StateAttacking()
    {
        /*if (entityStateCurrent == EntityStates.Dead)
            return;

        if (targetBehaviour.entityStateCurrent != EntityStates.Dead)
        {
            if (targetRangeCurrent <= targetRangeToAttack)
                enemyAttack.Attack();
            else
                SetCurrentState(AIState.Following);
        }
        else
            SetCurrentState(AIState.Idle);*/
    }

    public override void StateDead2()
    {

    }
    #endregion

    /// <summary>
    /// Checks the distance to an object
    /// </summary>
    /// <param name="_position"></param>
    /// <returns></returns>
    public float CheckDistanceToObj(Vector3 _position)
    {
        float _distance = Vector3.Distance(transform.position, _position);

        return _distance;
    }
}
