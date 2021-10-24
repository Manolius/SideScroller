using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MiloZitare
{

    public class EnemyController : MonoBehaviour
    {

        [SerializeField] public List<AttackType> healthBarCombo = new List<AttackType> {};
        [SerializeField] public int currentHealth;
        
        //----------EVENTS-----------
        public delegate void DelegateOnReceiveDamage();
        public event DelegateOnReceiveDamage OnReceiveDamage;

        public delegate void DelegateOnDeath();
        public event DelegateOnDeath OnDeath;

        IDeath death;

        public struct AttackInfo
        {
            public bool wasEffective;
            public bool didKill;
        }
        AttackInfo attackInfo = new AttackInfo();

        private void Start()
        {
            death = GetComponentInChildren<IDeath>();
            print("hola" + death);
        }

        void Awake()
        {
            healthBarCombo.Reverse();
        }

        private void OnEnable()
        {
            currentHealth = healthBarCombo.Count;
        }


        public AttackInfo RecieveDamage(AttackType _attackType)
        {
            if (currentHealth <= 0)
            {
                Die();
                attackInfo.wasEffective = true;
                return attackInfo;
            }

            if (_attackType.attackName == healthBarCombo[currentHealth - 1].attackName)
            {
                currentHealth -= 1;
                OnReceiveDamage.Invoke();
                if (currentHealth <= 0)
                {
                    Die();
                    attackInfo.didKill = true;
                }
                
                return attackInfo;
            }
            
                return attackInfo;
        }

        protected virtual void Die()
        {
            //Destroy(this.gameObject);
            if(OnDeath != null && OnDeath.Target != null)
            {
                death?.IsDead(true);
                OnDeath?.Invoke();
            }
            this.gameObject.SetActive(false);
        }
    }

   

}