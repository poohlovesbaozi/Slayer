
public class Hammer : Projectile
{
    protected override void OnEnable()
    {
        base.OnEnable();
        attack.currentDamage=attack.damage+FollowersData.followers[0].GetComponent<Character>().stats.Attack;
    }

}
