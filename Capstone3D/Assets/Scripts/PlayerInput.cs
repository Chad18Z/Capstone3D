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
    void Update()
    {


    }

    #endregion
}
