using UnityEngine;

public class Arrow : Projectile
{
    protected override void OnEnable()
    {
        base.OnEnable();
        if (FollowersData.followers.Count>2)
        attack.currentDamage+=FollowersData.followers[2].GetComponent<Character>().stats.Attack;
    }
    private void Start() {
        float z = Vector2.SignedAngle(Vector2.right,shootDir);
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
