using Atomic.Elements;
using UnityEngine;
using Utils;

namespace Mechanics
{
    public class DeathMechanics
    {
        private readonly GameObject _dyingObject;
        private readonly IAtomicObservable<int> _heals;

        public DeathMechanics(GameObject dyingObject, IAtomicObservable<int> heals)
        {
            _heals = heals;
            _dyingObject = dyingObject;
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
                MonoHelper.DestroyGO(_dyingObject);
            }
        }
    }
}
