using UnityEngine;

namespace Scenes.Player
{
    public class Mover : MonoBehaviour
    {
        private const float Speed = 12f;
        private const float JumpSpeed = 200f;
        private const int Orientation = -1;

        private Rigidbody _rigidBody;
        
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        
        private void FixedUpdate()
        {
            MovePlayer();
        }
        
        
        private void MovePlayer()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Move(Vector3.up);
            }
            
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
        }

        
        private void Move(Vector3 direction)
        {
            if (direction == Vector3.up && _rigidBody.velocity.y > 0)
                return;
            
            direction.x *= (Speed * Orientation);
            direction.y *= JumpSpeed;
            direction.z *= (Speed * Orientation);

            _rigidBody.AddForce(direction);
        }
    }
}
