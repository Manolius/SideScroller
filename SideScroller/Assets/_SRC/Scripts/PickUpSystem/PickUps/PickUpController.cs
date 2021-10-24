using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public abstract class PickUpController : MonoBehaviour
    {
        public delegate void DelegateDetachOwner();
        public event DelegateDetachOwner DetachOwner;

        public delegate void DelegateOnUseFinished();
        public event DelegateOnUseFinished OnUseFinished;

        //public delegate void FullResetDelegate();
        //public event FullResetDelegate onFullReset;

        public void Equip(Transform _equipPoint , DelegateDetachOwner _DetachMethod)
        {
            DetachOwner += _DetachMethod;
            this.gameObject.transform.position = _equipPoint.position;
            this.gameObject.transform.parent = _equipPoint;
        }
        
        /// <summary>
        /// Input the intended direction in a form of an angle from the Right vector
        /// </summary>
        /// <param name="_angleFromRight"></param>
        public virtual void Use(float _angleFromRight)
        {
            this.gameObject.SetActive(false);
        }

        /// <summary>
        /// When the object use is finished 
        /// </summary>
        protected virtual void DetachFromOwner()
        {
            transform.parent = null;
            transform.position -= Vector3.forward * 100; //Lo mueve a un lugar donde no se lo vera mas
            DetachOwner?.Invoke();
        }

        /// <summary>
        /// Call When The Object Actions are all finished (Used to respawn the PickUps) 
        /// </summary>
        protected virtual void UseFinished()
        {
            this.gameObject.SetActive(false);
            OnUseFinished?.Invoke();
        }

        protected virtual void OnDisable()
        {
            //DetachFromOwner();
            //DetachOwner?.Invoke();
            //if (!(bool)this.transform.parent?.gameObject.activeSelf)
            //{
            //    fullReset();
            //    onFullReset?.Invoke();
            //}
            //OnUseFinished();
        }

        public abstract void FullReset();
  

        //protected abstract void fullReset();

    }

}
