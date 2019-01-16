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
                Vector3 pointToLookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                gunTorus.transform.LookAt(pointToLookAt);
            }
        }
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
