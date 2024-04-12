using UnityEngine;

namespace Scenes.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float speed = 150f;
        [SerializeField] private float jumpSpeed = 5f;
        private Rigidbody _rigidBody;
        private const float MaxSpeed = 10f;

        private const int Orientation = -1;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            MovePlayer();
        }
        private void FixedUpdate()
        {
            if (_rigidBody.velocity.magnitude > MaxSpeed)
            {
                _rigidBody.velocity = _rigidBody.velocity.normalized * MaxSpeed;
            }
        }
        private void MovePlayer()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Move(Vector3.forward);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Move(Vector3.back);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Move(Vector3.left);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Move(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move(Vector3.up);
            }
        }

        private void Move(Vector3 direction)
        {
            direction.x = direction.x * speed * Time.deltaTime * Orientation;
            direction.y = direction.y * speed * Time.deltaTime * jumpSpeed;
            direction.z = direction.z * speed * Time.deltaTime * Orientation;

            _rigidBody.AddForce(direction);

            //transform.Translate(direction);
        }
    }
}
