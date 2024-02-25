using Objects;
using UnityEngine;
using Utils;

namespace Mechanics
{
    public class ShootingMechanics
    {
        private readonly Bullet _bulletPref;

        public ShootingMechanics(Bullet bulletPref)
        {
            _bulletPref = bulletPref;
        }

        public void Shoot(Transform spawnPoint)
        {
            var bullet = MonoHelper.CreateInstance(_bulletPref, spawnPoint.position);
            bullet.Move(spawnPoint.forward);
        }
    }
}
