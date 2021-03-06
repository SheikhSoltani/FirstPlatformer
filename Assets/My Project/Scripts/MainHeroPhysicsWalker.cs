using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroPhysicsWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private ContactsPoller _contactsPoller;

    public MainHeroPhysicsWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;

        _contactsPoller = new ContactsPoller(characterView.Collider);
    }


    public void FixedUpdate()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        bool doubleJump;
        var xAxisInput = Input.GetAxis(Horizontal);
        var doDash = Input.GetButtonDown("Fire1");

        _contactsPoller.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingTresh;

        if (isGoSideWay)
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;

        var newVelocity = 0f;

        if (isGoSideWay && !Mathf.Approximately(xAxisInput, 0))
        {
            newVelocity = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1); 
        }

        if (doDash==true)
        {
            //Debug.Log(Input.mousePosition);
            //doDash = false;
        }

        _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocity);

        if (_contactsPoller.IsGrounded && doJump && Mathf.Abs(_characterView.Rigidbody.velocity.y) <= _characterView.FlyTresh)
            _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpStartSpeed);//Debug.Log(_characterView.Rigidbody.velocity.y);
            
        if (_contactsPoller.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.run:Track.idle, true, 
                _characterView.AnimationsSpeed);
        }
        else if(Mathf.Abs(_characterView.Rigidbody.velocity.y) > _characterView.FlyTresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, true, 
                _characterView.AnimationsSpeed);
        }
    }
}
