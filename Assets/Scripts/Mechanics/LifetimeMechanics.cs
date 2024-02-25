using Atomic.Elements;
using UnityEngine;
using Utils;

namespace Mechanics
{
    public class LifetimeMechanics
    {
        private readonly GameObject _destructibleObject;
        private readonly IAtomicValue<float> _lifetime;
        
        private float _timer = 0;

        public LifetimeMechanics(GameObject destructibleObject, IAtomicValue<float> lifetime)
        {
            _destructibleObject = destructibleObject;
            _lifetime = lifetime;
        }

        public void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _lifetime.Value)
            {
                MonoHelper.DestroyGO(_destructibleObject);
            }
        }
    }
}
