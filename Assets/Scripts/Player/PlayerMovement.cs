using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private JoyStickController joyStickController;
    private CharacterController characterController;
    Vector3 moveVector;
    [SerializeField] private int moveSpeed;
    [SerializeField] private PlayerAnimator playerAnimator;
    private string lastSpeed = "lastSpeedKey";

    private float gravity = -9.81f;
    private float gravityMultiplier = 3f;
    private float gravityVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveSpeed = LoadSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveVector = joyStickController.GetMovePosition() * moveSpeed * Time.deltaTime / Screen.width;

        moveVector.z = moveVector.y;
        moveVector.y = 0;
        playerAnimator.ManageAnimations(moveVector);
        ApplyGravity();
        characterController.Move(moveVector);
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded && gravityVelocity < 0.0f)
        {
            gravityVelocity = -1f;
        }
        else
        {
            gravityVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        moveVector.y = gravityVelocity;
    }

    // Function to increase player speed
    public void IncreaseSpeed(int increment)
    {
        moveSpeed += increment;
        PlayerPrefs.SetInt(lastSpeed, moveSpeed);
    }
    private int LoadSpeed()
    {
        int lastLoadSpeed = PlayerPrefs.GetInt(lastSpeed, 250);
        return lastLoadSpeed;
    }
}
