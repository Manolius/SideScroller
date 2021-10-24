using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class AnimationBaseController : MonoBehaviour
    {

        protected Animator animator;

        public AnimationBaseController(Animator _animator)
        {
            animator = _animator;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (TryGetComponent<Animator>(out animator))
            {

            }
            else
            {
                animator = GetComponentInChildren<Animator>();
            }
        }


        protected void SetBool(string _boolName, bool _value)
        {
            animator.SetBool(_boolName, _value);
        }

        protected void SetFloat(string _floatName, float _value)
        {
            animator.SetFloat(_floatName, _value);
        }

        protected void SetTrigger(string _triggerName)
        {
            animator.SetTrigger(_triggerName);
        }
    }
}