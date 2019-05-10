using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnemySpotting : EntityEnemy
{
    public AIState aiCurrentState = AIState.Idle;

    public float maxRangeSpotting = 10f;
    public float timeSearching = 5f;


    //--------------------------------------------------------------------------

    /// <summary>
    /// Returns true if the target is spotted in the fov
    /// </summary>
    /// <param name="_fovAngle"></param>
    /// <returns>bool</returns>
    private bool Spotting(float _fovAngle)
    {
        Vector3 _pos = transform.position;

        bool _spotted = false;

        Vector3 _direction = targetObject.transform.position - _pos;
        float _angle = Vector3.Angle(_direction, transform.forward);


        if (_angle < aiFov * 0.5f)
        {
            RaycastHit _hit;

            if (Physics.Raycast(_pos + transform.up, _direction.normalized, out _hit))
            {
                if (_hit.collider.gameObject == targetObject)
                {
                    _spotted = true;
                }
            }

            Debug.DrawRay(transform.position, _direction * maxRangeSpotting, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, _direction * maxRangeSpotting, Color.red);
        }


        return _spotted;

    }


    //-------------------------
    //-----State functions-----
    //-------------------------

    public override void StateIdle()
    {
        if (Spotting(aiFov))
            SetCurrentState(AIState.Alerted);
    }

    public override void StateAlerted()
    {
        if (!Spotting(aiFov))
            SetCurrentState(AIState.Idle);
    }

    public override void StateSearching()
    {
        AlertedCountDown(timeSearching);
    }


    IEnumerator AlertedCountDown(float _time)
    {
        for (int i = 0; i < _time; i++)
        {
            if (i == _time)
                SetCurrentState(AIState.Idle);

            yield return new WaitForSeconds(i);
        }
    }
}
