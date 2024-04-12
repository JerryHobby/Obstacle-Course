using UnityEngine;
using UnityEngine.Events;

namespace Scenes.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static UnityEvent<int> OnScoreChanged;
        public static UnityEvent OnGameOver;

        public static GameManager Instance { get; private set; }
        public const float Bounciness = 50f;
        public bool MultipleHitsEnable { get; private set; } = false;
        
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            OnScoreChanged = new UnityEvent<int>();
            OnGameOver = new UnityEvent();
        }
    }
}
