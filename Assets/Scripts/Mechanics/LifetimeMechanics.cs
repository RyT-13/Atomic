using Atomic.Elements;
using UnityEngine;
using Utils;

namespace Mechanics
{
    public class LifetimeMechanics
    {
        private readonly GameObject _destructibleObject;
        private readonly IAtomicValue<float> _lifetime;
        private readonly IAtomicVariable<float> _currentTime;

        public LifetimeMechanics(GameObject destructibleObject, IAtomicValue<float> lifetime,
            IAtomicVariable<float> currentTime)
        {
            _destructibleObject = destructibleObject;
            _lifetime = lifetime;
            _currentTime = currentTime;
        }

        public void Update()
        {
            _currentTime.Value += Time.deltaTime;

            if (_currentTime.Value >= _lifetime.Value)
            {
                MonoHelper.DestroyGO(_destructibleObject);
            }
        }
    }
}
