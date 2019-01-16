using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Receive input from the player
/// </summary>
public class PlayerInput : MonoBehaviour
{
    #region Fields

    // Reference to this ship's rigidbody component
    Rigidbody rb;

    // How fast the ship accelerates
    float speed = 3f;

    // The ship's velocity, initialize to zero
    Vector3 moveVelocity = Vector3.zero;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {      
        rb = gameObject.GetComponent<Rigidbody>();
        //Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Get input values from each axis
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        // Velocity vector from player input
        moveVelocity = new Vector3(vInput * speed, 0, hInput * speed);
    }

    // Apply physics to game objects
    void FixedUpdate()
    {
        rb.velocity = moveVelocity;         
    }

    #endregion
}
