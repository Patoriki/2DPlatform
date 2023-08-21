using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    //public Vector2 velocity;
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(0.1f, 0);
    public float speed;
    public float speedRun;
    //public float fallingThreshold = 0.1f;
    public float forceJump = 15f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    //public float endJumpScaleY = 0.7f;
    public float jumpScaleX = 0.7f;
    //public float endJumpScaleX = 1.5f;
    public float animationJumpDuration = 0.3f;
    //public float animationFloorDuration = 0.1f;
    public Ease ease = Ease.OutBack;
    public string tagToLook = "Floor";
    //public bool falling;

    private float _currentSpeed;
    
    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleMovement();
        //CheckIfPlayerIsFalling();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;


        if ( Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }

        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationJumpDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    /*private void HandleEndScaleJump()
    {
        myRigidbody.transform.DOScaleY(endJumpScaleY, animationFloorDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(endJumpScaleX, animationFloorDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == tagToLook && falling)
        {
            HandleEndScaleJump();
        }
    }

    private void CheckIfPlayerIsFalling()
    {
        if(myRigidbody.velocity.y < fallingThreshold)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }*/
}
