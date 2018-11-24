using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float moveSpeed; // when player dies remember to set this to 0!

    bool Jumping;

    private bool isGrounded = false;

    private Rigidbody Rb; // private reference for Riigidbody
    private Animator Anim; // private reference for Animator

    public float gameSpeed = 0f; // reference for the amount of time left
    public int score = 0;
    public Text Scoretext; // reference the UI text

    // Use this for initialization-----------------------------------------------------------------------------------------------------------
    void Start()
    {

        isGrounded = false;

        Rb = GetComponent<Rigidbody>(); // fetch the rigidbody attached to this GO
        Anim = GetComponent<Animator>(); // fet the animator attached to this GO

    }

    // Update is called once per frame
    void Update()
    {
        //Constant Right Movement--------------------------------------------------------------------------------------------------------------

        Rb.velocity = new Vector3(moveSpeed, Rb.velocity.y); // moves the Rigidbody along the x axis at the movespeed float
        gameSpeed += Time.deltaTime; //time left minus delta time
        score = Mathf.RoundToInt(gameSpeed); //score int = time passed float but rounded to the nearest int
        Scoretext.text = score.ToString(); // set the timer passed text value to the score int string

        //Jumping------------------------------------------------------------------------------------------------------------------------------

        Anim.SetBool("isJumping", false); // ensures the boolean is set back to false for jumping in animator
        Jumping = false; // ensures the boolean is set back to false for jumping in script

        if (Input.GetMouseButtonDown(0) && (isGrounded == true))   // if the left mouse button is pressed and the player is grounded
        {
            Rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            Jumping = true; // set jumping to true in script
            isGrounded = false;
        }

        if (Jumping == true) // if jumping boolean is set to true in script
        {
            Anim.SetBool("isJumping", true); // set the jumping boolean to true in animator
        }

    }

    //Collision with the ground / isGrounded-------------------------------------------------------------------------------------------------

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    //Death --------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        Anim.SetBool("isDead", true);
        moveSpeed = 0;
        StartCoroutine(PauseGame());
    }

    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }
}
