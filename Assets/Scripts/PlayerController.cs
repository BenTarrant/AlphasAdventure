using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float moveSpeed; // when player dies remember to set this to 0!
    public float Gravity;


    bool Jumping;
    private bool isGrounded = false;

    private Rigidbody Rb; // private reference for Riigidbody
    private Animator Anim; // private reference for Animator

    public float gameSpeed = 0f; // reference for the amount of time left
    public int score = 0;
    public Text Scoretext; // reference the UI text


    public float LivesRemaining = 3f;
    public GameObject Life01;
    public GameObject Life02;
    public GameObject Life03;
    public Text LivesText;
    public GameObject RestartButton;


    private float verticalVelocity;
    

    // Use this for initialization-----------------------------------------------------------------------------------------------------------
    void Start()
    {

        //isGrounded = false;

        Rb = GetComponent<Rigidbody>(); // fetch the rigidbody attached to this GO
        Anim = GetComponent<Animator>(); // fet the animator attached to this GO
    }

    // Update is called once per frame
    void Update()
    {


        //Constant Right Movement--------------------------------------------------------------------------------------------------------------
        Rb.velocity = new Vector3(moveSpeed, Rb.velocity.y); // moves the Rigidbody along the x axis at the movespeed float



        gameSpeed += Time.deltaTime;
        moveSpeed += 0.1f * Time.deltaTime;
        score = Mathf.RoundToInt(gameSpeed); //score int = time passed float but rounded to the nearest int
        Scoretext.text = "Score: " + score.ToString(); // set the timer passed text value to the score int string


        LivesText.text = "Lives: " + LivesRemaining.ToString();

        //Jumping------------------------------------------------------------------------------------------------------------------------------

        Anim.SetBool("isJumping", false); // ensures the boolean is set back to false for jumping in animator
        GroundCheck(); // runs groundcheck raycast function
        Jumping = false; // ensures the boolean is set back to false for jumping in script


        if (Input.GetKeyDown("space") && (isGrounded == true))   // if the space button is pressed and the player is grounded
        {
            //Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
            //Rb.AddForce(new Vector2(0f, jumpForce * 10f));

            // CHECK THIS DOCUMENTATION: http://gamasutra.com/blogs/DanielFineberg/20150825/244650/Designing_a_Jump_in_Unity.php

            verticalVelocity = jumpForce;
            Jumping = true; // set jumping to true in script  
        }

        if (Jumping == true) // if jumping boolean is set to true in script
        {
            Anim.SetBool("isJumping", true); // set the jumping boolean to true in animator
        }
    }

    //Fucntions-----------------------------------------------------------------------------------------------------------------------------


    //Death --------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        LivesRemaining -= 1;
        //instatiate sparks and play audio que when 'damage' is taken
        if (LivesRemaining <= 0)
        {
            StartCoroutine("EndGame");
            RestartButton.SetActive(true);
        }
    }

    IEnumerator EndGame()
    {
        isGrounded = false;
        Anim.SetBool("isDead", true);
        moveSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    IEnumerator AddScore()
    {
        yield return new WaitForSeconds(1.5f);
        moveSpeed++;
    }

    //isGrounded--------------------------------------------------------------------------------------------------------------------------
    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);
        Debug.DrawRay(transform.position, dir, Color.red);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
            verticalVelocity = -Gravity * Time.deltaTime;
        }
        else
        {
            isGrounded = false;
            verticalVelocity -= Gravity * Time.deltaTime;
        }
    }




}

