using UnityEngine;

public class Arrow : Projectile
{
    private void Start() {
        float z = Vector2.SignedAngle(Vector2.right,shootDir);
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
