using Unity.VisualScripting;
using UnityEngine;
using static Scenes.Scripts.GameManager;

namespace Scenes.Scripts
{
    public class ObjectHit : MonoBehaviour
    {
        private Renderer _renderer;
        private const float FlashDuration = 0.2f;

        private float _delay;
        private float _timer;
        private bool _timerRunning;
    
        private delegate void Callback();

        private Callback _callback;
        private Material _glassMaterial;
        private Material _glassLitMaterial;
        private Material _wallMaterial;
        private Material _wallLitMaterial;
        private Material _blockMaterial;
        private Material _blockLitMaterial;
        private Material _spinnerMaterial;
        private Material _spinnerLitMaterial;
        private Material _pinBallMaterial;
        private Material _pinBallLitMaterial;
        private Material _bonusMaterial;
        private Material _bonusLitMaterial;

        private Material _currentMaterial;
        private Material _currentLitMaterial;

        public int HitCount { get; private set; } = 0;

        private string _objectKey;
        private void Start()
        {
            _glassMaterial = Resources.Load<Material>("Materials/Glass");
            _glassLitMaterial = Resources.Load<Material>("Materials/GlassLit");
            _wallMaterial = Resources.Load<Material>("Materials/Wall");
            _wallLitMaterial = Resources.Load<Material>("Materials/WallLit");
            _blockMaterial = Resources.Load<Material>("Materials/Block");
            _blockLitMaterial = Resources.Load<Material>("Materials/BlockLit");
            _spinnerMaterial = Resources.Load<Material>("Materials/Spinner");
            _spinnerLitMaterial = Resources.Load<Material>("Materials/SpinnerLit");
            _pinBallMaterial = Resources.Load<Material>("Materials/PinBall");
            _pinBallLitMaterial = Resources.Load<Material>("Materials/PinBallLit");
            _bonusMaterial = Resources.Load<Material>("Materials/Bonus");
            _bonusLitMaterial = Resources.Load<Material>("Materials/BonusLit");

            _timerRunning = false;
            _renderer = GetComponent<MeshRenderer>();
        }
    
        private void Update()
        {
            if (!_timerRunning) return;
        
            _timer += Time.deltaTime;
            if (_timer < _delay) return;
            
            _callback();
            _timerRunning = false;
        }
    
        private void OnCollisionEnter(Collision other)
        {
            HandleCollision(other);
        }

        private void StartTimer(float duration)
        {
            _delay = duration;
            _timer = 0;
            _timerRunning = true;
        }

        private void HandleCollision(Collision other)
        {
            if (_timerRunning) return;
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }


            if (gameObject.CompareTag("GlassWall"))
            {
                _currentMaterial = _glassMaterial;
                _currentLitMaterial = _glassLitMaterial;
            }

            if (gameObject.CompareTag("WoodenWall"))
            {
                _currentMaterial = _wallMaterial;
                _currentLitMaterial = _wallLitMaterial;                
            }
            
            if (gameObject.CompareTag("FallingCube"))
            {
                _currentMaterial = _blockMaterial;
                _currentLitMaterial = _blockLitMaterial;
            }
             
            if (gameObject.CompareTag("Spinner"))
            {
                _currentMaterial = _spinnerMaterial;
                _currentLitMaterial = _spinnerLitMaterial;
            }

            if (gameObject.CompareTag("PinBall"))
            {
                _currentMaterial = _pinBallMaterial;
                _currentLitMaterial = _pinBallLitMaterial;
            }
            
            
            if (gameObject.CompareTag("Bonus"))
            {
                _currentMaterial = _bonusMaterial;
                _currentLitMaterial = _bonusLitMaterial;
            }

            Hit();
        }
    
        private void Hit()
        {
            if (HitCount++ > 0 && !Instance.MultipleHitsEnable )
            {
                //Debug.Log("Been there done that.");
                return;
            }
            _renderer.material = _currentLitMaterial;

            if (!Instance.MultipleHitsEnable) return;
            
            _callback = Reset;
            StartTimer(FlashDuration);
        }
    
        private void Reset()
        {
            _renderer.material = _currentMaterial;
        }
    }
}
