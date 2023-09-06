

using UnityEngine;

public class LilRed : Enemy
{
    [SerializeField] GameObject Item;
    protected override void OnDie(){
        base.OnDie();
        if (Random.Range(1,4)==1)
        PoolManager.Release(Item,transform.position);
    }
}
