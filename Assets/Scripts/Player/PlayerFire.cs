using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed = 10.0f;
    public float bulletRate = 0.2f;
    public float bulletDestroyTime = 4.0f;
    private bool allowFire;

	// Use this for initialization
	void Start () {
        allowFire = true;
	}
	
	// Update is called once per frame
	void Update () {

        //fire bullets
        if (allowFire && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0)))
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
        Destroy(bullet, bulletDestroyTime);

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
