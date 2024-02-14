using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("属性")]
    [SerializeField]protected Attack attack;
    [SerializeField] float flySpd;
    [SerializeField]Rigidbody2D rb;
    public Vector2 shootDir;
    bool firstInit = true;

    //OnEnable会在初始化对象池时执行一次，所以对于实际发射所需执行的功能，则需要放在onenable之后。
    //但是放在awake中会导致无法获取rb，所以获取rb放在了onenable中
    protected virtual void Awake()
    {
        // rb = GetComponent<Rigidbody2D>();
        attack = GetComponent<Attack>();
    }
    protected virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        firstInit = false;
    }
    private void FixedUpdate()
    {
        if (!firstInit)
        {
            rb.AddForce(shootDir * flySpd, ForceMode2D.Impulse);
        }
    }

}
