using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip dodgeSound;

    private AudioSource _audioSource;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound() {
        _audioSource.PlayOneShot(attackSound);
    }

    public void PlayHitSound() {
        _audioSource.PlayOneShot(hitSound);
    }

    public void PlayDodgeSound() {
        _audioSource.PlayOneShot(dodgeSound);
    }
}
