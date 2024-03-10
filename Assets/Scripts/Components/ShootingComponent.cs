using System;
using Atomic.Elements;
using Mechanics;
using Objects;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class ShootingComponent
    {
        [SerializeField] private Bullet _bulletPref;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private ShootBulletAction _shootBulletAction;
        [SerializeField] private AtomicEvent _shootEvent;
        [SerializeField] private AndCondition _shootEnabled;
        
        public IAtomicAction ShootBulletAction => _shootBulletAction;
        public IAtomicObservable ShootEvent => _shootEvent;
        public AndCondition ShootEnabled => _shootEnabled;
        
        public void Compose()
        {
            _shootBulletAction.Compose(_bulletPref, _shootingPoint, _shootEvent, _shootEnabled);
        }
    }
}
