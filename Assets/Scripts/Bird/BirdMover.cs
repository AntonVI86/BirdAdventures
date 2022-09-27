using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAbilities))]
[RequireComponent(typeof(AudioSource))]
public class BirdMover : AnimatorHash
{
    [SerializeField] private AudioClip _flyingSound;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerAbilities _abilities;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _abilities = GetComponent<PlayerAbilities>();
    }

    public void Fly(float horizontalnput, float verticalInput)
    {
        _rigidbody.velocity = new Vector2(horizontalnput * _abilities.HorizontalSpeed, verticalInput * _abilities.VerticalSpeed);

        if(horizontalnput != 0 || verticalInput != 0)
        {
            _animator.Play(FlyHash);

            if(_audioSource.isPlaying == false)
                _audioSource.PlayOneShot(_flyingSound);
        }
    }
}
