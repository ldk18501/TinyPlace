using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{
    public class HeroCtrl : CharaCtrl
    {
        protected bool _bAttacking;
        private HeroModelMngr _modelMngr;
        public HeroModelMngr ModelMngr
        {
            get
            {
                if (_modelMngr == null)
                    _modelMngr = gameObject.GetComponent<HeroModelMngr>();
                return _modelMngr;
            } 
        }

        protected override void OnCharaStart()
        {
            base.OnCharaStart();
            _fsmChara.AddState(new CharaStateAttack((int)CharaStateEnum.Attack));
        }

        // Update is called once per frame
        protected override void OnCharaUpdate(float deltaTime)
        {
            base.OnCharaUpdate(deltaTime);
            CheckInput(Time.deltaTime);
        }

        protected void CheckInput(float deltaTime)
        {
            _v2Move = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
                _v2Move.y = 1;
            else if (Input.GetKey(KeyCode.S))
                _v2Move.y = -1;
            if (Input.GetKey(KeyCode.A))
                _v2Move.x = -1;
            else if (Input.GetKey(KeyCode.D))
                _v2Move.x = 1;

            _bAttacking = Input.GetKey(KeyCode.J);

            CheckState(deltaTime);
        }

        protected void CheckState(float deltaTime)
        {
            if (_bAttacking)
                _fsmChara.ChangeState((int)CharaStateEnum.Attack, null, true);
            else if (_v2Move != Vector2.zero)
                _fsmChara.ChangeState((int)CharaStateEnum.Move);
            else
                _fsmChara.ChangeState((int)CharaStateEnum.Idle);

            _fsmChara.TickState(deltaTime);
        }

    }
}
