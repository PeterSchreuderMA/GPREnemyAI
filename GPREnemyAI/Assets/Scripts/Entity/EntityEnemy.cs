
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Idle,
    Alerted,
    Following,
    Attacking,
    Searching,
    Dead,
}

public class EntityEnemy : Entity
{
    public GameObject enemyTarget;

    public float targetCurrentRange;
    public float enemyAttackRange = 1f;
    public float enemySpotRange = 6f;

    public AIState enemyStateCurrent = AIState.Idle;

    //---------------
    //-----State-----
    //---------------

    public void SetCurrentState(AIState _value)
    {
        enemyStateCurrent = _value;
        print("Set enemy state to:" + _value);
    }

    public AIState CheckState()
    {
        if (entityHealthStateCurrent != EntityHealthStates.Dead)
        {
            switch (enemyStateCurrent)
            {
                case AIState.Idle:
                    StateDefault();
                    StateIdle();
                    break;

                case AIState.Alerted:
                    StateDefault();
                    StateAlerted();
                    break;

                case AIState.Searching:
                    StateDefault();
                    StateSearching();
                    break;

                case AIState.Following:
                    StateDefault();
                    StateFollowing();
                    break;

                case AIState.Attacking:
                    StateDefault();
                    StateAttacking();
                    break;

                case AIState.Dead:
                    StateDefault();
                    StateDead2();
                    break;
            }
        }
        else
        {
            StateDead2();
        }


        return enemyStateCurrent;
    }

    //-------------------------
    //-----State functions-----
    //-------------------------

    #region State Functions
    public virtual void StateDefault()
    {
        
    }

    public virtual void StateIdle()
    {
        
    }

    public virtual void StateAlerted()
    {

    }

    public virtual void StateSearching()
    {

    }

    public virtual void StateFollowing()
    {
        
    }

    public virtual void StateAttacking()
    {
        
    }

    public virtual void StateDead2()
    {

    }
    #endregion


    public void OnDrawGizmos()//visual for minimum attack range
    {
        if (enemyTarget != null)
        {
            UnityEditor.Handles.color = Color.blue;
            UnityEditor.Handles.DrawLine(transform.position, enemyTarget.transform.position);   //DrawWireDisc(transform.position, Vector3.up, enemySpotRange);
        }

        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, enemySpotRange);

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, enemyAttackRange);
    }
}
