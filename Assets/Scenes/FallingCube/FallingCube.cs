using UnityEngine;
using UnityEngine.Rendering;

namespace Scenes.FallingCube
{
    public class FallingCube : MonoBehaviour
    {
        [SerializeField] private float delay = 5f;
         
        private Renderer _meshRenderer;
        private Rigidbody _boxRigidBody;

        
        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _boxRigidBody = gameObject.GetComponent<Rigidbody>();
            
            Hide();
        }
        
        // Update is called once per frame
        private void Update()
        {
            ShowAfterDelay();
        }

        
        private void ShowAfterDelay()
        {
            if (_meshRenderer.enabled) return;

            if (Time.time < delay) return;
            
            Show();
        }
        
        private void Hide()
        {
            _meshRenderer.enabled = false;
            _meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
            _boxRigidBody.useGravity = false;
        }
        
        
        private void Show()
        {
            _meshRenderer.enabled = true;
            _meshRenderer.shadowCastingMode = ShadowCastingMode.On;
            _boxRigidBody.useGravity = true;
        }
    }
}