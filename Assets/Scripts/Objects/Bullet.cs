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
        public AtomicVariable<float> currentLifetime;

        [SerializeField] private Rigidbody _rigidbody;

        private MovementMechanics _movementMechanics;
        private LifetimeMechanics _lifetimeMechanics;
        
        [SerializeField] private DealDamageAction _dealDamageAction;

        private void Awake()
        {
            _dealDamageAction.Compose(damage);
            _movementMechanics = new MovementMechanics(_rigidbody, new AtomicValue<bool>(true), moveSpeed, moveDirection);
            _lifetimeMechanics = new LifetimeMechanics(gameObject, lifetime, currentLifetime);
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
                _dealDamageAction.Invoke(target);
                MonoHelper.DestroyGO(gameObject);
            }
        }

        public void Move(Vector3 direction)
        {
            moveDirection.Value = direction;
        }
    }
}
