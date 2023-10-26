using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStats : MonoBehaviour
{
    [SerializeField] MinionStatsSO minionStats;
    public int MaxHp{
        get{if (minionStats==null) return 0;else return minionStats.maxHp;}
        // set{minionStats.maxHp=value;}
    }
    public int CurrentHp{
        get{if (minionStats==null) return 0;else return minionStats.currentHp;}
        set{minionStats.currentHp=value;}
    }
    public float CheckRadius{
        get{if (minionStats==null) return 0;else return minionStats.checkRadius;}
    }
    public float NormalSpd{
        get{{if (minionStats==null) return 0;else return minionStats.normalSpd;}}
    }
    public float DashSpd{
        get{if (minionStats==null) return 0;else return minionStats.dashSpd;}
    }
    public float CurrentSpd{
        get{if (minionStats==null) return 0;else return minionStats.currentSpd;}
        set{minionStats.currentSpd=value;}
    }
    public int DropRate{
        get{if (minionStats==null) return 0;else return minionStats.dropRate;}
    }
    public float HitForce{
        get{if (minionStats==null) return 0;else return minionStats.hitForce;}
    }
}
