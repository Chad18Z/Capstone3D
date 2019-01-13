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

    // Reference to the ship's cabin (the sphere)
    GameObject sphere;

    // How fast the player's ship rotates when the mouse is moved
    float rotationSpeed = 25f;

    // Reference to this ship's rigidbody component
    Rigidbody rb;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        gunTorus = GameObject.FindGameObjectWithTag("gunTorus");
        sphere = GameObject.FindGameObjectWithTag("sphere");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * rotationSpeed;
        Debug.Log(x);
        gunTorus.transform.Rotate(Vector3.forward, x);

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.back * 10f);
            //sphere.transform.rotation = new Quaternion(0, 90f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.forward * 10f);
            //sphere.transform.rotation = new Quaternion(0, -90f, 0, 0);
        }
    }


    #endregion
}
