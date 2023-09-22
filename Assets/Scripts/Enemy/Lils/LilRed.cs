using UnityEngine;

public class LilRed : Enemy
{
    [SerializeField] GameObject Item;

    protected override void Awake(){
        base.Awake();
        moveState=new LilsMoveState();
    }
    public override void OnDie(){
        base.OnDie();
        if (Random.Range(1,4)==1)
        PoolManager.Release(Item,transform.position);
    }
}
