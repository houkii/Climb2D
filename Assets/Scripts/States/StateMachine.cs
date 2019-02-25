﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour {

    private PlayerState _currentState;
    public PlayerState currentState
    {
        get { return _currentState; }
        private set
        {
            _currentState = value;
            currentStateName = _currentState.GetName();
        }
    }

    public string currentStateName;
    public static PlayerStates PlayerStates = new PlayerStates();

    private GameObject Target;
    private PlayerState nextState;
    private static PlayerState _previousState;
    public static PlayerState previousState
    {
        get { return _previousState; }
        private set
        {
            _previousState = value;
        }
    }

    //public UnityAction OnStateChanged;


    // Use this for initialization
    private void Start () {

        this.Target = transform.gameObject;
        PlayerState.Target = this.transform.gameObject;
        this.currentState = PlayerStates.IdleAir;
        this.currentState.OnStateEnter();
    }
	
	// Update is called once per frame
	private void FixedUpdate () {

        nextState = currentState.Update();
        if(nextState != currentState)
        {
            this.SwitchStates(nextState);
        }

	}

    public void SwitchStates(PlayerState state)
    {
        if(state != currentState)
        {
            currentState.OnStateExit();
            previousState = currentState;
            currentState = state;
            currentState.OnStateEnter();
        }
    }

    //public delegate IEnumerator crFunction();
    //public void SetPlayerCoroutine(crFunction function)
    //{
    //    StartCoroutine(function());
    //}
}

public class PlayerStates
{
    public IdleGround IdleGround = new IdleGround();
    public IdleAir IdleAir = new IdleAir();
    public Handling Handling = new Handling();
    public Dead Dead = new Dead();
    public Rotating Rotating = new Rotating();
    public JumpReady JumpReady = new JumpReady();
    public DoubleGrab DoubleGrab = new DoubleGrab();
}