using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("属性")]
    protected Attack attack;
    [SerializeField] float flySpd;
    Rigidbody2D rb;
    public Vector2 shootDir;

    //OnEnable会在初始化对象池时执行一次，所以对于实际发射所需执行的功能，则需要放在onenable之后。
    protected virtual void OnEnable()
    {
        rb=GetComponent<Rigidbody2D>();
        attack=GetComponent<Attack>(); 
    }
    private void Start() {

        rb.AddForce(shootDir*flySpd,ForceMode2D.Impulse);
    }


}
