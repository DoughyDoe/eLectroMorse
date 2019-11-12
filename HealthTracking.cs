using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracking : MonoBehaviour {
    public Sprite[] HealthStages;
    public GameObject player;
    public HealthManagement playerHealthManager;

    private float maxHp;
    // Use this for initialization
    void Start () {
        maxHp = playerHealthManager.HP;
        GetComponent<SpriteRenderer>().sprite = HealthStages[HealthStages.Length];
	}
	
	// Update is called once per frame
	void Update () {
        
        float HP = playerHealthManager.HP;
        float stageCount = HealthStages.Length;
        int healthStageIndex = 0;
        if (HP < maxHp)
        {
            
            float stage = (HP * stageCount) / maxHp;
            healthStageIndex = (int)Mathf.Ceil(stage);
        }
        else
        {
            healthStageIndex = (int)stageCount;
        }
        
        GetComponent<SpriteRenderer>().sprite = HealthStages[healthStageIndex];
    }
}
