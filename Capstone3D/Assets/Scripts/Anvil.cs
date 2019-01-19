using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the behavior of the anvil
/// </summary>
public class Anvil : MonoBehaviour
{
    #region Fields

    // Reference to camera needed for raycasting into scene
    [SerializeField]
    Camera mainCamera;

    // Reference to the rotating cannon
    GameObject gunTorus;

    // Raycasting for mouse position. We need a plane for the ray to intersect with
    [SerializeField]
    GameObject groundPlane;

    // Distance from the player character in which the mouse cursor is detectable
    float mouseRadius = 2.04f;

    // State machine support
    AnvilStates state = AnvilStates.IDLE;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        gunTorus = GameObject.FindGameObjectWithTag("gunTorus");
    }

    // Update is called once per frame
    void Update()
    {
        // The cannons should always face the mouse cursor
        // Shoot a ray from the camera to the mouse cursor
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) >= mouseRadius)
            {
                if (state == AnvilStates.INVISIBLE)
                {
                    // The mouse cursor is outside of the player character's radius, let's change the state to "easing"
                    state = AnvilStates.EASING;

                    // Store the ship's current rotation. We'll send this to the Coroutine
                    Quaternion currentRotation = gunTorus.transform.rotation;

                    // Calculate the direction from the ship to the mouse cursor. We'll need this to calculate the angle to rotate towards
                    Vector3 targetDirection = hit.point - transform.position;

                    // Create Quaternion for target rotation
                    Quaternion targetRotation = Quaternion.FromToRotation(gunTorus.transform.forward, targetDirection);

                    // Begin rotation
                    StartCoroutine(RotateShip(currentRotation, targetRotation));
                }
                else
                {
                    Vector3 pointToLookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    gunTorus.transform.LookAt(pointToLookAt);
                }
            }
            else if (state == AnvilStates.IDLE)
            {
                state = AnvilStates.INVISIBLE;
            }
        }
    }

    /// <summary>
    /// Coroutine to smoothly rotate the ship
    /// </summary>
    /// <returns></returns>
    IEnumerator RotateShip(Quaternion currentRotation, Quaternion targetRotation)
    {
        //for (float f = 0; f <= 1; f += .01f)
        //{
        //    //Quaternion.Slerp(currentRotation, targetRotation, f);
        yield return null;
        //}
        //// Easing is complete. Change state back to IDLE
        state = AnvilStates.IDLE;
    }

    #endregion
}
