using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class MovementMechanics
    {
        private readonly Rigidbody _rigidbody;
        private readonly IAtomicValue<bool> _enabled;
        private readonly IAtomicValue<float> _moveSpeed;
        private readonly IAtomicValue<Vector3> _moveDirection;

        public MovementMechanics(Rigidbody rigidbody, IAtomicValue<bool> enabled, IAtomicValue<float> moveSpeed, IAtomicValue<Vector3> moveDirection)
        {
            _rigidbody = rigidbody;
            _enabled = enabled;
            _moveSpeed = moveSpeed;
            _moveDirection = moveDirection;
        }

        public void FixedUpdate()
        {
            if (_enabled.Value)
            {
                _rigidbody.velocity = _moveDirection.Value * _moveSpeed.Value;
            }
        }
    }
}
