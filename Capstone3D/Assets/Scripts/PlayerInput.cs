using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Receive input from the player
/// </summary>
public class PlayerInput : MonoBehaviour
{
    #region Fields

    // Reference to the rotating cannon
    GameObject gunTorus;

    // Raycasting for mouse position. We need a plane for the ray to intersect with
    public Plane groundPlane;

    // How fast the player's ship rotates when the mouse is moved
    float rotationSpeed = 10f;

    // Reference to this ship's rigidbody component
    Rigidbody rb;

    // How fast the ship accelerates
    float speed = 5f;

    // The ship's velocity, initialize to zero
    Vector3 moveVelocity = Vector3.zero;

    // Rotation of the ship
    Quaternion rot;

    // Hold input
    float hInput; // horizontal axis
    float vInput; // vertical axis

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        gunTorus = GameObject.FindGameObjectWithTag("gunTorus");
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void Update()
    {
        // Get input values from each axis
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // Velocity vector from player input
        moveVelocity = new Vector3(vInput * speed, 0, hInput * speed);

        // The cannons should always face the mouse cursor
        // Shoot a ray from the camera to the mouse cursor
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float rayLength;

       // if (groundPlane.Raycast

    }

    // Apply physics to game objects
    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    #endregion
}
