using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class MovementMechanics
    {
        private readonly Rigidbody _rigidbody;
        private readonly IAtomicValue<float> _moveSpeed;
        private readonly IAtomicValue<Vector3> _moveDirection;

        public MovementMechanics(Rigidbody rigidbody, IAtomicValue<float> moveSpeed, IAtomicValue<Vector3> moveDirection)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
            _moveDirection = moveDirection;
        }

        public void FixedUpdate()
        {
            _rigidbody.velocity = _moveDirection.Value * _moveSpeed.Value;
        }
    }
}
