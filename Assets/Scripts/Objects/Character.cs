using Atomic.Elements;
using Components;
using Mechanics;
using UnityEngine;

namespace Objects
{
    public class Character : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootingComponent _shootingComponent;

        [SerializeField] private AtomicFunction<bool> _isIdle;

        private RotateMechanics _rotateMechanics;

        public IAtomicValue<bool> IsIdle => _isIdle;
        public IAtomicValue<bool> IsMoving => _moveComponent.IsMoving;
        public IAtomicObservable DeathEvent => _healthComponent.DeathEvent;
        public IAtomicObservable ShootEvent => _shootingComponent.ShootEvent;

        private void Awake()
        {
            _healthComponent.Compose(gameObject);
            _moveComponent.Compose();
            _shootingComponent.Compose();

            _isIdle.Compose(() => _moveComponent.IsMoving.Value == false && _healthComponent.IsAlive.Value);
            _moveComponent.MoveEnabled.Append(_healthComponent.IsAlive);
            _shootingComponent.ShootEnabled.Append(_healthComponent.IsAlive);
            _shootingComponent.ShootEnabled.Append(
                new AtomicFunction<bool>(() => _moveComponent.IsMoving.Value == false));

            _rotateMechanics = new RotateMechanics(_moveComponent.MoveDirection, transform, _moveComponent.MoveEnabled);
        }

        private void OnEnable()
        {
            _healthComponent.OnEnable();
        }

        private void OnDisable()
        {
            _healthComponent.OnDisable();
        }

        private void FixedUpdate()
        {
            _moveComponent.FixedUpdate();
        }

        private void Update()
        {
            _rotateMechanics.Update();
        }

        public void Move(Vector3 direction)
        {
            _moveComponent.MoveDirection.Value = direction;
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamageAction.Invoke(damage);
        }

        public void Shoot()
        {
            _shootingComponent.ShootBulletAction.Invoke();
        }
    }
}
