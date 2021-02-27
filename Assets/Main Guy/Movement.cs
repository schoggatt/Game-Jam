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

    private void Start()
    {
        CamTransform = Camera.main.transform; // Attach cam
    }

    void Update()
    {
        var direction = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("RunningSpeed", direction);
        animator.SetFloat("IsRunning", Mathf.Abs(direction));
        horizontalMove = direction * runSpeed;
    }

    /// <summary>
    /// Called every fixed frame rate
    /// </summary>
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        CamTransform.position = new Vector3(PlayerTransform.position.x, CamTransform.position.y, CamTransform.position.z);


        jump = false;
    }
}
