using Objects;
using UnityEngine;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void Update()
        {
            var direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }
        
            _character.Move(direction);

            if (Input.GetMouseButtonDown(0))
            {
                _character.Shoot();
            }
        }
    }
}
