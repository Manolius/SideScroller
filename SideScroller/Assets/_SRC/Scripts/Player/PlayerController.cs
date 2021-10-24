using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiloZitare
{

    public class PlayerController : MonoBehaviour
    {
       // WorldCheckPoint currentCheckPoint;

        public delegate void PlayerDeathDelegate();
        public event PlayerDeathDelegate PlayerDeath; 

        public delegate void CheckPointReachedDelegate();
        public event CheckPointReachedDelegate _CheckPointReached;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Kill();
            }
        }

        public void RecieveDamage()
        {
            Kill();
        }
        public void Kill()
        {
            this.gameObject.SetActive(false);
            PlayerDeath?.Invoke();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        public void CheckPointReached()
        {
            _CheckPointReached?.Invoke();
        }
    }
}
