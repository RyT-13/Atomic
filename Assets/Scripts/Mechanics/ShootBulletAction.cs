using System;
using Atomic.Elements;
using Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Utils;

namespace Mechanics
{
    [Serializable]
    public class ShootBulletAction : IAtomicAction
    {
        private Bullet _bulletPref;
        private Transform _spawnPoint;
        private IAtomicEvent _shootEvent;
        private IAtomicValue<bool> _enabled;

        public ShootBulletAction()
        {
        }

        public ShootBulletAction(Bullet bulletPref, Transform shootingPoint, IAtomicEvent shootEvent,
            AndCondition enabled)
        {
            _bulletPref = bulletPref;
            _spawnPoint = shootingPoint;
            _shootEvent = shootEvent;
            _enabled = enabled;
        }

        public void Compose(Bullet bulletPref, Transform shootingPoint, IAtomicEvent shootEvent,
            AndCondition enabled)
        {
            _bulletPref = bulletPref;
            _spawnPoint = shootingPoint;
            _shootEvent = shootEvent;
            _enabled = enabled;
        }

        [Button]
        public void Invoke()
        {
            if (_enabled.Value)
            {
                var bullet = MonoHelper.CreateInstance(_bulletPref, _spawnPoint.position);
                bullet.Move(_spawnPoint.forward);
                _shootEvent.Invoke();
            }
        }
    }
}
