using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class IdleAnimMechanics
    {
        private static readonly int MainState = Animator.StringToHash("MainState");
        
        private readonly Animator _animator;
        private readonly IAtomicValue<bool> _isIdle;

        public IdleAnimMechanics(Animator animator, IAtomicValue<bool> isIdle)
        {
            _animator = animator;
            _isIdle = isIdle;
        }

        public void Update()
        {
            if (_isIdle.Value)
            {
                _animator.SetInteger(MainState, 0);
            }
        }
    }
}
