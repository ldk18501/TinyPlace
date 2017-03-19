using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlace
{
    public class CharaCtrl : MonoBehaviour
    {
        protected StateMachine<CharaCtrl> _fsmChara;
        protected Animator _anim;

        public Animator AnimCtrller
        {
            get { return _anim; }
        }

        protected Vector2 _v2Move;

        // Use this for initialization
        void Awake()
        {
            _anim = gameObject.GetComponent<Animator>();
            _fsmChara = new StateMachine<CharaCtrl>(this);
        }
        void Start()
        {
            OnCharaStart();
        }
        protected virtual void OnCharaStart()
        {
            _fsmChara.AddState(new CharaStateIdle((int)CharaStateEnum.Idle));
            _fsmChara.AddState(new CharaStateMove((int)CharaStateEnum.Move));
        }

        void Update()
        { 
            OnCharaUpdate(Time.deltaTime);
        }
        protected virtual void OnCharaUpdate(float deltaTime)
        { }


        public void PlayAnim(string stateName, float fadeTime = 0.2f, int animLayer = 0)
        {
            _anim.CrossFade(stateName, 0.2f, animLayer);
        }
        public bool IsAnimInState(string stateName, int animLayer = 0)
        {
            return _anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName);
        }
        public float GetCurAnimProgress(string stateName, int animLayer = 0)
        {
            if (_anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName))
                return _anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime;
            return 0;
        }
    }
}
