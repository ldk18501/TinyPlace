using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StateMachine<T>
{
    private T _owner;
    private State<T> _stateCur;
    public State<T> CurState
    {
        get { return _stateCur; }
    }
    //private State<T> _statePrev;
    private int _nCurStateEnum = -1;

    private Dictionary<int, State<T>> _dicStates = new Dictionary<int, State<T>>();
    private bool _bIsStateChanging;

    private object _curChangingParam;

    public StateMachine(T owner)
    {
        _owner = owner;
    }

    public void AddState(State<T> state)
    {
        _dicStates.Add(state.StateEnum, state);
        state.SetOwner(_owner);
    }

    public void ChangeState(int stateEnum, object param = null, bool isForce = false)
    {
        if (_stateCur == null && _dicStates.ContainsKey(stateEnum))
        {
            _nCurStateEnum = stateEnum;
            _stateCur = _dicStates[stateEnum];
            _stateCur.Enter(param);
        }
        else
        {
            if (_bIsStateChanging)
                return;

            if (_dicStates.ContainsKey(stateEnum))
            {
                if (!isForce && _nCurStateEnum == stateEnum)
                    return;

                if (_stateCur.HandleNextState(stateEnum))
                {
                    _bIsStateChanging = true;
                    _curChangingParam = param;
                }
            }
        }
    }

    //! 状态机更新
    public string TickState(float deltaTime)
    {
        if (_stateCur != null)
        {
            if (_bIsStateChanging)
            {
                if (_dicStates.ContainsKey(_stateCur.NextStateEnum))
                {
                    var prevState = _nCurStateEnum;
                    _nCurStateEnum = _stateCur.NextStateEnum;
                    //_statePrev = _stateCur;
                    _stateCur.Exit();
                    _stateCur = _dicStates[_nCurStateEnum];
                    _stateCur.PrevStateEnum = prevState;
                    _stateCur.Enter(_curChangingParam);

                    _curChangingParam = null;
                }
                _bIsStateChanging = false;
            }
            return _stateCur.Execute(deltaTime);
        }
        return null;
    }

    public void CleanState()
    {
        _stateCur = null;
    }
}

public class State<T>
{
    protected T _owner;
    protected string _strStateStatus;
    public string StrStateStatus
    {
        get { return _strStateStatus; }
    }

    protected readonly int _nStateEnum;
    public int StateEnum
    {
        get { return _nStateEnum; }
    }

    protected int _nPrevStateEnum;
    public int PrevStateEnum
    {
        set { _nPrevStateEnum = value; }
    }

    protected int _nNextStateEnum;
    public int NextStateEnum
    {
        get { return _nNextStateEnum; }
    }

    public State(int stateEnum)
    {
        _nStateEnum = stateEnum;
    }

    public void SetOwner(T owner)
    {
        _owner = owner;
    }

    public virtual void Enter(object param)
    {
        _strStateStatus = null;
    }
    public virtual string Execute(float deltaTime)
    {
        return _strStateStatus;
    }
    public virtual void Exit()
    {
    }

    public virtual bool HandleNextState(int stateEnum)
    {
        _nNextStateEnum = stateEnum;
        return true;
    }
}