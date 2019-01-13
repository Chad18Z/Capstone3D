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

    // Player object starting z value
    float zValue;

    // Position of mouse cursor
    Vector3 mouse;

    // Rotation of the ship
    Quaternion rot;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        gunTorus = GameObject.FindGameObjectWithTag("gunTorus");
        Debug.Log(gunTorus);

        zValue = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouse = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Vector3 diff = new Vector3(mouse.x - transform.position.x, mouse.y - transform.position.y, zValue);
        float angle = Mathf.Atan2(diff.y, diff.x);

        //gunTorus.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        gunTorus.transform.Rotate(0f, 0f, angle);
    }

    #endregion
}
