using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    private float moveInput;
    public float moveSpeed = 5f;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public float JumpForce;
    private float jumptimecounter;
        public float jumpTime;
    private bool isJumping;
    public Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (moveInput > 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
 } else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0 , 0);
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
         

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
           
            isJumping = true;
            animator.SetBool("IsJumping", true);
            jumptimecounter = jumpTime;
            rb.velocity = Vector2.up * JumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
       

            if (jumptimecounter > 0)
            {
                
                rb.velocity = Vector2.up * JumpForce;
                jumptimecounter -= Time.deltaTime;
                
            } else {
                animator.SetBool("IsJumping", false);
                isJumping = false;
                
                


            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            
        }
      
        
    }
  

    
}
