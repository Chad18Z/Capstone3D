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
    float mouseRadius = 2.05f;

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
                    float currentAngle = gunTorus.transform.eulerAngles.y;

                    // Calculate the direction from the ship to the mouse cursor. We'll need this to calculate the angle to rotate towards
                    Vector3 targetDirection = hit.point - transform.position;

                    // Calculate the target angle IN DEGREES 
                    float angle = Mathf.Atan2(targetDirection.z, targetDirection.x) * Mathf.Deg2Rad;

                    float targetAngle = angle;

                    StartCoroutine(RotateShip(currentAngle, targetAngle));
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
                // Here I will add the code to make the anvil "disappear" in front of the player character
            }
        }
    }

    /// <summary>
    /// Coroutine to smoothly rotate the ship
    /// </summary>
    /// <returns></returns>
    IEnumerator RotateShip(float currentAngle, float targetAngle)
    {
        Vector3 temp = transform.eulerAngles;
        for (float f = 0; f <= 1; f += .1f)
        {
            //gunTorus.transform.rotation = Quaternion.Slerp(currentAngle, targetAngle, f);
            //float ease = EaseOutBounceD(currentAngle, targetAngle, f);
            //temp.y = ease;
            //gunTorus.transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }

        // Easing is complete. Change state back to IDLE
        state = AnvilStates.IDLE;
    }

    /// <summary>
    /// Easing function for mouse rotation
    /// Created by C.J. Kimberlin (http://cjkimberlin.com)
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    float EaseOutBounceD(float start, float end, float value)
    {
        value /= 1f;
        end -= start;

        if (value < (1 / 2.75f))
        {
            return 2f * end * 7.5625f * value;
        }
        else if (value < (2 / 2.75f))
        {
            value -= (1.5f / 2.75f);
            return 2f * end * 7.5625f * value;
        }
        else if (value < (2.5 / 2.75))
        {
            value -= (2.25f / 2.75f);
            return 2f * end * 7.5625f * value;
        }
        else
        {
            value -= (2.625f / 2.75f);
            return 2f * end * 7.5625f * value;
        }
    }

    #endregion
}
