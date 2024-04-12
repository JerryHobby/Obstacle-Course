using System.Collections;
using Scenes.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.HUD
{
    public class GameOverLabel : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Start()
        {
            GameManager.OnGameOver.AddListener(OnGameOver);
            _textMesh = GetComponent<TextMeshProUGUI>();

            
        }

        
        private IEnumerator WaitForSpaceKey()
        {
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
            ReloadGame();
        }
        
        
        private void ReloadGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnGameOver()
        {
            _textMesh.enabled = true;
            StartCoroutine(WaitForSpaceKey());
        }
    }
}