using Atomic.Elements;
using Mechanics;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Bullet : MonoBehaviour
    {
        public AtomicValue<float> moveSpeed;
        public AtomicVariable<Vector3> moveDirection;
        public AtomicValue<float> lifetime;
        public AtomicValue<int> damage;
        
        [SerializeField] private Rigidbody _rigidbody;
        
        private MovementMechanics _movementMechanics;
        private LifetimeMechanics _lifetimeMechanics;
        private DealDamageMechanics _dealDamageMechanics;

        private void Awake()
        {
            _movementMechanics = new MovementMechanics(_rigidbody, moveSpeed, moveDirection);
            _lifetimeMechanics = new LifetimeMechanics(gameObject, lifetime);
            _dealDamageMechanics = new DealDamageMechanics(damage);
        }
        
        private void FixedUpdate()
        {
            _movementMechanics.FixedUpdate();
        }

        private void Update()
        {
            _lifetimeMechanics.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable target))
            {
                _dealDamageMechanics.DealDamage(target);
                MonoHelper.DestroyGO(gameObject);
            }
        }

        public void Move(Vector3 direction)
        {
            moveDirection.Value = direction;
        }
    }
}
