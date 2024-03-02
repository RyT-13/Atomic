using System;
using Atomic.Elements;
using Objects;

namespace Mechanics
{
    [Serializable]
    public class DealDamageAction : IAtomicAction<IDamageable>
    {
        private IAtomicValue<int> _damage;

        public DealDamageAction()
        {
        }

        public DealDamageAction(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        public void Compose(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        public void Invoke(IDamageable target)
        {
            target.TakeDamage(_damage.Value);
        }
    }
}
