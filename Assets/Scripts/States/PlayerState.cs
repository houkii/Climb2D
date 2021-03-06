﻿using UnityEngine;

public abstract class PlayerState {

    private static GameObject _Target;
    public static GameObject Target
    {
        get { return _Target; }
        set
        {
            _Target = value;
            TargetController = _Target.GetComponent<PlayerController>();
        }
    }

    private static PlayerController _TargetController;
    protected static PlayerController TargetController
    {
        get { return _TargetController; }
        set
        {
            _TargetController = value;
        }
    }

    public abstract string GetName();

    public virtual void OnStateEnter()
    {
        Debug.Log(this.GetName() + " OnStateEnter called.");
    }

    public virtual void OnStateExit()
    {
        Debug.Log(this.GetName() + " OnStateExit called.");
    }

    public virtual PlayerState Update()
    {
        return HandleInput();
    }

    public virtual PlayerState HandleInput()
    {
        return this;
    }
}
