using Scenes.Scripts;
using TMPro;
using UnityEngine;

namespace Scenes.HUD
{
    public class ScoreLabel : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Start()
        {
            GameManager.OnScoreChanged.AddListener(UpdateScore);
            _textMesh = GetComponent<TextMeshProUGUI>();
            _textMesh.text = "Hits: 0";
        }

        private void UpdateScore(int score)
        {
            _textMesh.text = $"Hits: {score}";
        }
    }
}
