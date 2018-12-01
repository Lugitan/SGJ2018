using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour {

    public float maxDistance;
    public static List<AIBehaviour> enemies = new List<AIBehaviour>();

    void Start()
    {
        enemies.Add(this);
    }

    public static void PlayerMakesSound(Vector3 position, float factor)
    {
        enemies.RemoveAll(item => item == null);
        foreach (AIBehaviour ai in enemies)
        {
            if (Vector3.Distance(ai.transform.position, position) < ai.maxDistance)
            {
                ai.ReceivePlayerSound(position, factor);
            }
        }
    }

    public virtual void ReceivePlayerSound(Vector3 position, float factor)
    {
        
    }
}
