using UnityEngine;

public class LilRed : Enemy
{
    protected override void Awake(){
        base.Awake();
        moveState=new LilsMoveState();
    }
    public override void OnDie(){
        base.OnDie();
        Destroy(gameObject);
    }
}
