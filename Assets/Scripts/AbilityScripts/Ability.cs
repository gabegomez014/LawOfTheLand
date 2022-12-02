using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName = "New Ability";
    public GameObject deathParticles;
    public Sprite abilitySprite;
    public AudioClip abilitySound;
    public AnimationClip abilityAnim;
    public float abilityBaseCoolDown = 1f;
    public float abilityDuration;
    public float deathDuration;
    public float damage;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
