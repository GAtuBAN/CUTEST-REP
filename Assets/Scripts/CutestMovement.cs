
using UnityEngine;

public class CutestMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]private float speed;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        //AN�MASYON EKLEN�NCE YORUMDAN �IKAR
        //anim = GetComponent<Animator>();

    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //left right hareketi
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //sa�a/sola d�nd���nde v�cudunu o y�ne �evirecek
        //k�saca flipping
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;

        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);

        }




        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();

        }
        // AN�MASYON EKLEY�NCE YORUMDAN �IKAR
        //SET ANIM PARAMETERS
        //anim.SetBool("run", horizontalInput != 0);
        //anim.SetBool("grounded", grounded);

        

      
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        //anim.SetTrigger("jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    

}
