using System;
using Atomic.Elements;
using Mechanics;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class HealthComponent
    {
        [SerializeField] private AtomicVariable<int> _health;
        [SerializeField] private TakeDamageAction _takeDamageAction;
        [SerializeField] private AtomicVariable<bool> _isAlive = new(true);
        [SerializeField] private AtomicEvent _deathEvent;
        
        private DeathMechanics _deathMechanics;

        public TakeDamageAction TakeDamageAction => _takeDamageAction;
        public IAtomicValue<bool> IsAlive => _isAlive;
        public IAtomicObservable DeathEvent => _deathEvent;

        public void Compose(GameObject _dyingObject)
        {
            _takeDamageAction.Compose(_health);

            _deathMechanics = new DeathMechanics(_health, _deathEvent);
            
            _deathEvent.Subscribe(() => _isAlive.Value = false);
        }

        public void OnEnable()
        {
            _deathMechanics.OnEnable();
        }

        public void OnDisable()
        {
            _deathMechanics.OnDisable();
        }
    }
}
