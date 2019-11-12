using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickup : MonoBehaviour {
    public HealthManagement PlayerHealthManger;
    public int HPReward;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            PlayerHealthManger.HP += HPReward;
            Destroy(gameObject, 0.0f);
        }
    }
}
