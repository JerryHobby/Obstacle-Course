using Scenes.Scripts;
using UnityEngine;

namespace Scenes.Player
{
    public class Scorer : MonoBehaviour
    { 
        private int Score { get; set; }

        
        public void AddScore(int value)
        {
            Score += value;
            GameManager.OnScoreChanged.Invoke(Score);
        }
    }
}
