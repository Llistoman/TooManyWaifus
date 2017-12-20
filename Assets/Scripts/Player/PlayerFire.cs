using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject level;
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
        if (nwaifus >= 1)
        {
            realBulletSpeed = bulletSpeed * 2.0f;
            realBulletRate = bulletRate / 2.0f;
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
        //fire patterns
        if(nwaifus == 0 || nwaifus == 1)
        {
            GameObject bullet1 = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            bullet1.transform.forward = transform.forward;
            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * realBulletSpeed;
        }
        if(nwaifus == 2)
        {
            GameObject bullet2 = Instantiate(BulletPrefab, BulletSpawn.transform.position + (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet2.transform.forward = transform.forward;
            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * realBulletSpeed;

            GameObject bullet3 = Instantiate(BulletPrefab, BulletSpawn.transform.position - (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet3.transform.forward = transform.forward;
            bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * realBulletSpeed;
        }
        if(nwaifus == 3)
        {
            GameObject bullet2 = Instantiate(BulletPrefab, BulletSpawn.transform.position + (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet2.transform.forward = transform.forward;
            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * realBulletSpeed;

            GameObject bullet3 = Instantiate(BulletPrefab, BulletSpawn.transform.position - (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet3.transform.forward = transform.forward;
            bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * realBulletSpeed;

            GameObject bullet4 = Instantiate(BulletPrefab, BulletSpawn.transform.position + (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet4.transform.forward = transform.forward + (transform.forward + transform.right);
            bullet4.GetComponent<Rigidbody>().velocity = bullet4.transform.forward * realBulletSpeed;

            GameObject bullet5 = Instantiate(BulletPrefab, BulletSpawn.transform.position - (0.25f * BulletSpawn.transform.right), BulletSpawn.transform.rotation);
            bullet5.transform.forward = transform.forward + (transform.forward - transform.right);
            bullet5.GetComponent<Rigidbody>().velocity = bullet5.transform.forward * realBulletSpeed;
        }

        float elapsedTime = 0;
        while (elapsedTime <= realBulletRate)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        allowFire = true;
        level.GetComponent<AudioManager>().PlayFire();
        yield return 0;
    }
}
