using System;
using Atomic.Elements;
using Mechanics;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField] private AtomicValue<float> _moveSpeed;
        [SerializeField] private AtomicVariable<Vector3> _moveDirection;
        [SerializeField] private AndCondition _moveEnabled;
        [SerializeField] private AtomicFunction<bool> _isMoving;
        
        [SerializeField] private Rigidbody _rigidbody;

        private MovementMechanics _movementMechanics;

        public AndCondition MoveEnabled => _moveEnabled;
        public IAtomicValue<bool> IsMoving => _isMoving;
        public IAtomicVariable<Vector3> MoveDirection => _moveDirection;

        public void Compose()
        {
            _movementMechanics = new MovementMechanics(_rigidbody, _moveEnabled, _moveSpeed, _moveDirection);
            
            _isMoving.Compose(() => _moveDirection.Value != Vector3.zero && _moveEnabled.Invoke());
        }

        public void FixedUpdate()
        {
            _movementMechanics.FixedUpdate();
        }
    }
}
