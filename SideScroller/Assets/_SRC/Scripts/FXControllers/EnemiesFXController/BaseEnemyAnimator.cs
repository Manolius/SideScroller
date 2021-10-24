using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class BaseEnemyAnimator : AnimationBaseController , IDeath
    {
        public BaseEnemyAnimator(Animator _animator) : base(_animator)
        {
            animator = _animator;
        }

        public void IsDead(bool _IsDead = true)
        {
            SetBool(EnemyAnimatorVarsConsts.IS_DEAD, _IsDead);
            Debug.Log(_IsDead);
        }
    }

  
}
