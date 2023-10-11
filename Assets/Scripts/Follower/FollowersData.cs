using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersData : MonoBehaviour
{
    public static List<GameObject> followers;
    private void Awake() {
        followers=new ();
    }
}
