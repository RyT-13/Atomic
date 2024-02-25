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
        [SerializeField]
        private TakeDamageMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private ShootingMechanics _shootingMechanics;

        private void Awake()
        {
            _movementMechanics = new MovementMechanics(_rigidbody, moveSpeed, moveDirection);
            _takeDamageMechanics = new TakeDamageMechanics(health);
            _deathMechanics = new DeathMechanics(gameObject, health);
            _shootingMechanics = new ShootingMechanics(_bulletPref);
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
            _takeDamageMechanics.TakeDamage(damage);
        }

        public void Shoot()
        {
            _shootingMechanics.Shoot(_shootingPoint);
        }
    }
}
