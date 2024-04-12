using UnityEngine;

namespace Scenes.Spinner
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;

        private void Update()
        {
            transform.Rotate(0f, speed * Time.deltaTime * 10, 0f);
        }
    }
}
