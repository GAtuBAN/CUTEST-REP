
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
        //ANÝMASYON EKLENÝNCE YORUMDAN ÇIKAR
        //anim = GetComponent<Animator>();

    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //left right hareketi
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //saða/sola döndüðünde vücudunu o yöne çevirecek
        //kýsaca flipping
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
        // ANÝMASYON EKLEYÝNCE YORUMDAN ÇIKAR
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
