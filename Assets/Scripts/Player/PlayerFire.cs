using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed;
    public float bulletRate;
    private bool allowFire;
    public float aux;

	// Use this for initialization
	void Start () {
        allowFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        aux = Input.GetAxis("Triggers");
        //fire bullets
        if (allowFire && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Triggers") < (-0.5f)))
        {
            allowFire = false;
            StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        bullet.transform.forward = transform.forward;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        float elapsedTime = 0;
        while (elapsedTime <= bulletRate)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        allowFire = true;
        yield return 0;
    }
}
