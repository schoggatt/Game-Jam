using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Player Movement
/// </summary>
public class Movement : MonoBehaviour
{
    #region References
    public CharacterController2D controller;
    public Transform CamTransform;
    public Transform PlayerTransform;
    public Animator animator;
    #endregion
    #region Fields
    bool jump;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    #endregion

    private Vector3 lastPosition = Vector3.zero;
    private double speed;

    private void Start()
    {
        speed = 0;
        CamTransform = Camera.main.transform; // Attach cam
    }

    void Update()
    {
        var direction = Input.GetAxisRaw("Horizontal");
        if(speed != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false); 
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //animator.SetTrigger("Jump");
            jump = true;
        }
        horizontalMove = direction * runSpeed;


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Called every fixed frame rate
    /// </summary>
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        CamTransform.position = new Vector3(PlayerTransform.position.x, CamTransform.position.y, CamTransform.position.z);

        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        jump = false;
    }
}
