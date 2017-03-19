using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{

    public enum CharaStateEnum
    {
        Idle,
        Move,
        Attack,
    }

    public class CharaStateIdle : State<CharaCtrl>
    {
        public CharaStateIdle(int stateEnum)
            : base(stateEnum)
        {
        }

        public override void Enter(object param)
        {
            Debug.Log("idle");
            base.Enter(param);
            _owner.PlayAnim("Idle");
        }

        public override string Execute(float deltaTime)
        {
            return base.Execute(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }

    public class CharaStateMove : State<CharaCtrl>
    {
        public CharaStateMove(int stateEnum)
            : base(stateEnum)
        { }

        public override void Enter(object param)
        {
            Debug.Log("move");
            base.Enter(param);
            _owner.PlayAnim("Run");
        }

        public override string Execute(float deltaTime)
        {
            return base.Execute(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }

    public class CharaStateAttack : State<CharaCtrl>
    {
        int _nAtkAnimLayer = 0;
        static string[] _strStateNames = { "Melee Right Attack 01", "Melee Right Attack 02", "Melee Right Attack 03" };
        string _strCurStateName;
        int _nAtkIndex;
        bool _bAniming;
        public CharaStateAttack(int stateEnum)
            : base(stateEnum)
        { }

        public override void Enter(object param)
        {
            Debug.Log("atk");
            base.Enter(param);

            if (_nPrevStateEnum != _nStateEnum)
                _nAtkIndex = 0;
            //Debug.Log((CharaStateEnum)_nPrevStateEnum);

            if (!_bAniming)
            {
                _strCurStateName = _strStateNames[_nAtkIndex];
                _owner.PlayAnim(_strCurStateName);
                if (++_nAtkIndex > _strStateNames.Length - 1)
                    _nAtkIndex = 0;
            }
        }

        public override string Execute(float deltaTime)
        {
            if (!_bAniming && _owner.IsAnimInState(_strCurStateName, _nAtkAnimLayer))
                _bAniming = true;

            return base.Execute(deltaTime);
        }

        public override void Exit()
        {
            _bAniming = false;
            base.Exit();
        }

        public override bool HandleNextState(int stateEnum)
        {
            if (_bAniming)
            {
                float fadeRate = stateEnum == _nStateEnum ? 0.7f : 1f;
                if (_owner.GetCurAnimProgress(_strCurStateName, _nAtkAnimLayer) >= fadeRate)
                {
                    _nNextStateEnum = stateEnum;
                    _bAniming = false;
                    return true;
                }
            }

            return false;
        }
    }
}