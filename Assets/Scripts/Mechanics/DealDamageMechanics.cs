using Atomic.Elements;
using Objects;

namespace Mechanics
{
    public class DealDamageMechanics
    {
        private readonly IAtomicValue<int> _damage;

        public DealDamageMechanics(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        public void DealDamage(IDamageable target)
        {
            target.TakeDamage(_damage.Value);
        }
    }
}
