using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    public float moveSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Gravity and Ground Check")]
    public Transform groundCheckPoint;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 movement;
    Vector3 velocity;
    public bool isGrounded;
    public bool isJumping;
    public bool isMoving;

    public int playerIndex;


    [Header("SFX")]
    public List<AudioClip> footstepClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0; // Track the current clip index

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this GameObject.");
        }

        if (footstepClips.Count == 0)
        {
            Debug.LogError("No footstep audio clips assigned.");
        }
    }

    void Update()
    {
        //check if grounded
        GroundCheck();

        // Handle movement input
        HandleMovementInput();

        if (isMoving && !audioSource.isPlaying && (isGrounded || playerIndex ==2))
        {
            PlayFootstep();
        }


        CheckJump();
        
    }

    void FixedUpdate()
    {
        // Move the player
        MovePlayer();

        //Not on the ground apply gravity
        if (!isGrounded)
        {
            CheckGravity();
        }
        else if (velocity.y < 0)
        {
            //reset velocity, -2f缓冲
            velocity.y = -2f;
        }

            
    }

    void HandleMovementInput()
    {
        // Get input from the WASD keys or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        if (movement != Vector3.zero)// for footsteps
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    void MovePlayer()
    {
        // Move the player based on the movement vector
        controller.Move(movement * moveSpeed * Time.deltaTime);

    }

    void GroundCheck()
    {
        //check if player is within ground distance with objects in ground layer
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundDistance, groundMask);
    }
    void CheckGravity()
    {
        //gravity formular = 1/2gt^2, so time square
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void CheckJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void PlayFootstep()
    {
        if (footstepClips.Count > 0 && audioSource != null)
        {
            AudioClip clip = footstepClips[currentClipIndex]; // Get the current clip
            audioSource.PlayOneShot(clip); // Play the clip

            currentClipIndex++; // Move to the next clip

            // Loop back to the first clip if we've reached the end
            if (currentClipIndex >= footstepClips.Count)
            {
                currentClipIndex = 0;
            }
        }
    }
}
