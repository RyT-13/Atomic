using Atomic.Elements;
using Mechanics;
using UnityEngine;

namespace Objects
{
    public class Character : MonoBehaviour, IDamageable
    {
        public AtomicVariable<int> health;

        public AtomicValue<float> moveSpeed;
        public AtomicVariable<Vector3> moveDirection;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Bullet _bulletPref;
        [SerializeField] private Transform _shootingPoint;

        private MovementMechanics _movementMechanics;
        private DeathMechanics _deathMechanics;

        [SerializeField] private TakeDamageAction _takeDamageAction;
        [SerializeField] private ShootBulletAction _shootBulletAction;

        private void Awake()
        {
            _takeDamageAction.Compose(health);
            _shootBulletAction.Compose(_bulletPref);

            _movementMechanics = new MovementMechanics(_rigidbody, moveSpeed, moveDirection);
            _deathMechanics = new DeathMechanics(gameObject, health);
        }

        private void OnEnable()
        {
            _deathMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _deathMechanics.OnDisable();
        }

        private void FixedUpdate()
        {
            _movementMechanics.FixedUpdate();
        }

        public void Move(Vector3 direction)
        {
            moveDirection.Value = direction;
        }

        public void TakeDamage(int damage)
        {
            _takeDamageAction.Invoke(damage);
        }

        public void Shoot()
        {
            _shootBulletAction.Invoke(_shootingPoint);
        }
    }
}
