using System;
using Mechanics;
using UnityEngine;

namespace Objects
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;

        private IdleAnimMechanics _idleMechanics;
        private MoveAnimMechanics _moveMechanics;
        private DeathAnimMechanics _deathMechanics;
        private ShootAnimMechanics _shootMechanics;

        private void Awake()
        {
            _idleMechanics = new IdleAnimMechanics(_animator, _character.IsIdle);
            _moveMechanics = new MoveAnimMechanics(_animator, _character.IsMoving);
            _deathMechanics = new DeathAnimMechanics(_animator, _character.DeathEvent);
            _shootMechanics = new ShootAnimMechanics(_animator, _character.ShootEvent);
        }

        private void OnEnable()
        {
            _deathMechanics.OnEnable();
            _shootMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _deathMechanics.OnDisable();
            _shootMechanics.OnDisable();
        }

        private void Update()
        {
            _idleMechanics.Update();
            _moveMechanics.Update();
        }
    }
}
