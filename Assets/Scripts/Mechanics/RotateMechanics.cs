using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class RotateMechanics
    {
        private readonly IAtomicValue<Vector3> _moveDirection;
        private readonly Transform _transform;
        private readonly IAtomicValue<bool> _enabled;

        public RotateMechanics(IAtomicValue<Vector3> moveDirection, Transform transform, IAtomicValue<bool> enabled)
        {
            _moveDirection = moveDirection;
            _transform = transform;
            _enabled = enabled;
        }

        public void Update()
        {
            if (_enabled.Value && _moveDirection.Value != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(_moveDirection.Value, Vector3.up);
                _transform.rotation = rotation;
            }
        }
    }
}
