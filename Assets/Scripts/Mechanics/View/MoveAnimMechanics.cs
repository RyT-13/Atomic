using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class MoveAnimMechanics
    {
        private static readonly int MainState = Animator.StringToHash("MainState");
        
        private readonly Animator _animator;
        private readonly IAtomicValue<bool> _isMoving;

        public MoveAnimMechanics(Animator animator, IAtomicValue<bool> isMoving)
        {
            _animator = animator;
            _isMoving = isMoving;
        }

        public void Update()
        {
            if (_isMoving.Value)
            {
                _animator.SetInteger(MainState, 1);
            }
        }
    }
}
