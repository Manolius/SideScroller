using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiloZitare
{
    public class PickUp_ProjectileSpawn : PickUpController
    {
        [SerializeField] GameObject Projectile;
        [SerializeField] int maxAmmo = 1;
        [SerializeField]protected List<GameObject> ammo;
        int currentAmmo;
        private bool isFullReseting;

        private void Start()
        {
            if(Projectile == null)
            {
                Debug.LogError($"{this.gameObject.name} {this} projectile is configured to null");
            }
            for (int i = 0; i < maxAmmo; i++)
            {
                GameObject _GOtmp = Instantiate(Projectile);
                ProjectileController _PCtmp = _GOtmp.GetComponent<ProjectileController>();
                _PCtmp.OnProjectileDeath += CheckProjectiles;
                _GOtmp.SetActive(false);
                ammo.Add(_GOtmp);
            }
            currentAmmo = ammo.Count;
        }

        public override void Use(float _angleFromRight)
        {
            if(currentAmmo > 0)
            {
                GameObject _projectile = ammo[0];
                ammo.RemoveAt(0);
                ammo.Add(_projectile);
                _projectile.transform.position = this.transform.position;
                _projectile.transform.rotation = Quaternion.AngleAxis(_angleFromRight, Vector3.forward);
                _projectile.SetActive(true);
                currentAmmo--;
                CheckProjectiles();
            }
            if (currentAmmo <= 0)
            {
                DetachFromOwner();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            currentAmmo = ammo.Count;
        }

        private void CheckProjectiles()
        {
            if (isFullReseting) return;
            foreach (GameObject _projectile in ammo)
            {
                if (_projectile.activeInHierarchy || currentAmmo > 0)
                {
                    return;
                }
            }
            //DetachFromOwner();
            UseFinished();
        }

        public override void FullReset()
        {
            isFullReseting = true;
            foreach (var _projectile in ammo)
            {
                _projectile.SetActive(false);
            }
            DetachFromOwner();
            this.gameObject.SetActive(false);
            isFullReseting = false;
        }

    }

}
