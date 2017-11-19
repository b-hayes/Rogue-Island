using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 20;
	public float speed = 10.0f;
    public string hurts = "monster";
	public float lifetime = 5.0f;
	public GameObject bullet_prefab;
	public float cooldown = 0.5f;
	float timeElapsed;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update() {
		timeElapsed += Time.deltaTime;
		if (Input.GetAxis ("Fire1") > 0.9f) {
            shoot();
		}
	}

    public bool shoot()
    {
        if (timeElapsed < cooldown)
        {
            return false; //dont shoot if the shooter is on coolDown. (will be handy when manually calling shoot from AI scripts)
        }
        //shooter defines the position scale and colour of bullets shot from it everything is copied form shooter to bullet
        GameObject bullet = Instantiate(bullet_prefab, transform.position, transform.rotation);
        bullet.transform.localScale = transform.localScale;
        bullet.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        Bullet stats = bullet.GetComponent<Bullet>();
        stats.speed = speed;
        stats.damage = damage;
        stats.hurts = hurts;
        stats.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        Destroy(bullet.gameObject, lifetime);
        timeElapsed = 0.0f;
        return true;
    }
}
