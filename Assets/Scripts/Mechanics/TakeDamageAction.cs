using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Mechanics
{
    [Serializable]
    public class TakeDamageAction : IAtomicAction<int>
    {
        private IAtomicVariable<int> _health;

        public TakeDamageAction()
        {
        }

        public TakeDamageAction(IAtomicVariable<int> health)
        {
            _health = health;
        }

        public void Compose(IAtomicVariable<int> health)
        {
            _health = health;
        }
        
        [Button]
        public void Invoke(int damage)
        {
            _health.Value -= damage;
        }
    }
}
