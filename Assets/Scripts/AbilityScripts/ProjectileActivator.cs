using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileActivator : MonoBehaviour
{
    public Animator anim;
    public Transform spawnLocation;
    private GameObject _projectile;
    private GameObject _deathParticles;
    private AnimationClip _animClip;

    private float _projectileForce = 250f;
    private float _abilityDuration = 1.5f;
    private float _deathParticlesDuration = 1.5f;

    // Start is called before the first frame update
    public void SetProjectileForce(float force) {
        _projectileForce = force;
    }

    public void SetProjectile(GameObject projectile) {
        _projectile = projectile;
    }

    public void SetAbilityDuration(float duration) {
        _abilityDuration = duration;
    }

    public void SetDeathParticles(GameObject deathParticles) {
        _deathParticles = deathParticles;
    }

    public void SetAnimationClip(AnimationClip clip) {
        _animClip = clip;
    }

    public void SetDeathParticlesDuration(float duration) {
        _deathParticlesDuration = duration;
    }

    public void Activate() {
        GameObject clonedProjectile = GameObject.Instantiate(_projectile, spawnLocation.position, this.transform.rotation);
        Rigidbody rb = clonedProjectile.GetComponent<Rigidbody>();
        AbilityDeathHandler deathHandler = clonedProjectile.GetComponent<AbilityDeathHandler>();

        rb.AddForce(this.transform.forward * _projectileForce, ForceMode.VelocityChange);
        deathHandler.SetAbilityTransform(clonedProjectile.transform);
        deathHandler.SetDeathParticles(_deathParticles);
        deathHandler.SetAbilityDuration(_abilityDuration);
        deathHandler.SetDeathParticlesDuration(_deathParticlesDuration);

    }


}
