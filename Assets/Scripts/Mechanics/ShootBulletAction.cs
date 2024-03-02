using System;
using Atomic.Elements;
using Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Utils;

namespace Mechanics
{
    [Serializable]
    public class ShootBulletAction : IAtomicAction<Transform>
    {
        private Bullet _bulletPref;

        public ShootBulletAction()
        {
        }

        public ShootBulletAction(Bullet bulletPref)
        {
            _bulletPref = bulletPref;
        }

        public void Compose(Bullet bulletPref)
        {
            _bulletPref = bulletPref;
        }

        [Button]
        public void Invoke(Transform spawnPoint)
        {
            var bullet = MonoHelper.CreateInstance(_bulletPref, spawnPoint.position);
            bullet.Move(spawnPoint.forward);
        }
    }
}
