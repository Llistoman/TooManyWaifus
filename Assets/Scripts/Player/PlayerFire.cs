using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed;
    public float realBulletSpeed;
    public float bulletRate;
    public float realBulletRate;
    private bool allowFire;
    private float nwaifus;

	// Use this for initialization
	void Start () {
        allowFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        nwaifus = this.gameObject.GetComponent<WaifuController>().nwaifus;

        if (nwaifus == 0)
        {
            realBulletRate = bulletRate;
            realBulletSpeed = bulletSpeed;
        }
        if (nwaifus == 1)
        {
            realBulletSpeed = bulletSpeed * 1.5f;
        }
        if (nwaifus == 2)
        {
            realBulletRate = bulletRate / 1.5f;
        }

        //fire bullets
        if (allowFire && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Triggers") < (-0.5f)))
        {
            allowFire = false;
            StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        GameObject bullet1 = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        bullet1.transform.forward = transform.forward;
        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * realBulletSpeed;

        if(nwaifus == 3)
        {
            GameObject bullet2 = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            bullet2.transform.forward = transform.forward + transform.right;
            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * realBulletSpeed;

            GameObject bullet3 = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            bullet3.transform.forward = transform.forward - transform.right;
            bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * realBulletSpeed;
        }

        float elapsedTime = 0;
        while (elapsedTime <= realBulletRate)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        allowFire = true;
        yield return 0;
    }
}
