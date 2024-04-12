using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;

namespace Scenes.Player
{
    public class Player : MonoBehaviour
    {
        private Scorer _scorer;
        private readonly List<int> _hitList = new List<int>();
        
        private void Start()
        {
            _scorer = GetComponent<Scorer>();
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Base")) return;

            var objId = other.gameObject.GetInstanceID();
            
            if (_hitList.Contains(objId) 
                && !GameManager.Instance.MultipleHitsEnable)
            {
                return;
            }
            _hitList.Add(objId);

            if (other.gameObject.CompareTag("Bonus"))
            {
                _scorer.AddScore(500);

            } else if (other.gameObject.CompareTag("Finish"))
            {
                _scorer.AddScore(1000);
                GetComponent<Mover>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameManager.OnGameOver.Invoke();
            }
            else if (other.gameObject.CompareTag("Floor"))
            {
                _scorer.AddScore(-1000);
                GetComponent<Mover>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameManager.OnGameOver.Invoke();
            }
            else
            {
                _scorer.AddScore(-100);
            }
        }
    }
}