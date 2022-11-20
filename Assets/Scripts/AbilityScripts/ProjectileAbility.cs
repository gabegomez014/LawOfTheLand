using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {

    public float projectileForce = 500f;
    public GameObject projectile;

    private ProjectileActivator activator;
    public override void Initialize(GameObject obj)
    {
        activator = obj.GetComponent<ProjectileActivator>();
        activator.SetProjectileForce(projectileForce);
        activator.SetProjectile(projectile);
        activator.SetDeathParticles(deathParticles);
        activator.SetAbilityDuration(abilityDuration);
        activator.SetDeathParticlesDuration(deathDuration);
        activator.SetAnimationClip(abilityAnim);
        activator.SetDamage(damage);
    }

    public override void TriggerAbility()
    {
        activator.Activate();
    }

}
