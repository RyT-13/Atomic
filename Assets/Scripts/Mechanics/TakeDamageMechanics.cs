using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Mechanics
{
    [Serializable]
    public class TakeDamageMechanics
    {
        private readonly IAtomicVariable<int> _health;

        public TakeDamageMechanics(IAtomicVariable<int> health)
        {
            _health = health;
        }
        
        [Button]
        public void TakeDamage(int damage)
        {
            _health.Value -= damage;
        }
    }
}
