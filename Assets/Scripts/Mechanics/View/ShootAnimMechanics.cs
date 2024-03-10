using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class ShootAnimMechanics
    {
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private readonly Animator _animator;
        private readonly IAtomicObservable _shootEvent;

        public ShootAnimMechanics(Animator animator, IAtomicObservable shootEvent)
        {
            _animator = animator;
            _shootEvent = shootEvent;
        }

        public void OnEnable()
        {
            _shootEvent.Subscribe(OnShoot);
        }

        public void OnDisable()
        {
            _shootEvent.Unsubscribe(OnShoot);
        }

        private void OnShoot()
        {
            _animator.SetTrigger(Shoot);
        }
    }
}
