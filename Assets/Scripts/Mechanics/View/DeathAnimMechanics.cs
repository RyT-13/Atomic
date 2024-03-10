using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class DeathAnimMechanics
    {
        private static readonly int MainState = Animator.StringToHash("MainState");

        private readonly Animator _animator;
        private readonly IAtomicObservable _deathEvent;

        public DeathAnimMechanics(Animator animator, IAtomicObservable deathEvent)
        {
            _animator = animator;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _deathEvent.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _deathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            _animator.SetInteger(MainState, 2);
        }
    }
}
