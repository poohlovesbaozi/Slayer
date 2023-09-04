

using UnityEngine;

public class LilRed : Enemy
{
    [SerializeField] GameObject Item;
    protected override void OnDie(){
        base.OnDie();
        if (Random.Range(0,10)>=5)
        PoolManager.Release(Item,transform.position);
    }
}
