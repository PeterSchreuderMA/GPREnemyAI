using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityHealthStates
{
    Alive,
    Dead
}

public class Entity : MonoBehaviour
{
    private float entityHealthCurrent { get; set; }

    public EntityHealthState entityHealthStateCurrent = EntityHealthStates.Alive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
