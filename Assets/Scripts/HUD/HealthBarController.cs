using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    public GameObject target;
    public GameObject text;
    private float total;
    private float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target.CompareTag("Player"))
        {
            total = target.GetComponent<PlayerController>().totalHP;
            health = target.GetComponent<PlayerController>().HP;

            text.GetComponent<Text>().text = "HP: " + health.ToString() + "/" + total.ToString();

            if (health == 0)
                transform.localScale = Vector3.zero;
            else
                transform.localScale = new Vector3(health/total,transform.localScale.y, transform.localScale.z);
        }
        else if(target.CompareTag("Boss"))
        {
            total = target.GetComponent<BossController>().totalHP;
            health = target.GetComponent<BossController>().HP;
            if (health == 0)
                transform.localScale = Vector3.zero;
            else
                transform.localScale = new Vector3(health / total, transform.localScale.y, transform.localScale.z);
        }
		
	}
}
