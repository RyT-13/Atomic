using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class DeathMechanics
    {
        private readonly GameObject _dyingObject;
        private readonly IAtomicObservable<int> _heals;
        private readonly IAtomicEvent _deathEvent;

        public DeathMechanics(IAtomicObservable<int> heals, IAtomicEvent deathEvent)
        {
            _heals = heals;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _heals.Subscribe(HealsChanged);
        }

        public void OnDisable()
        {
            _heals.Unsubscribe(HealsChanged);
        }

        private void HealsChanged(int heals)
        {
            if (heals <= 0)
            {
                _deathEvent?.Invoke();
            }
        }
    }
}
