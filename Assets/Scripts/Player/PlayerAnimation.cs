using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController playerController;
    private void Awake() {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        playerController=GetComponent<PlayerController>();
    }
    private void Update() {
        SetAnimation();
    }

    public void SetAnimation()
    {
        anim.SetFloat("velocity",Mathf.Abs(rb.velocity.x)+Mathf.Abs(rb.velocity.y));
        anim.SetBool("isDead",playerController.isDead);
    }
    public void PlayerGetHit(){
        anim.SetTrigger("hit");
    }
}
