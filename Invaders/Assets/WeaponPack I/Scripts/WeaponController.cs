using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	
	public enum Type {Sniper, Rifle, Automatic, Knife}
	public Type type;
	
	public float animSpeed = 1;
	public float fireRate = 0.1f;
    public Camera fpsCam;

    public AudioSource audio;
    public AudioClip gunShot;
    public AudioClip emptyShot;

    public GameObject blood;

    public float damage;

    float nextFire = 0;

    public int maxAmmo;
    public int maxClip;
    private int currentClip;
    private int currentAmmo;
	
	// Use this for initialization
	void Awake () {
        currentAmmo = maxAmmo;
        currentClip = maxClip;

		if(type == Type.Sniper){
			GetComponent<Animation>()["Reload_1_3"].wrapMode = WrapMode.Once;
			GetComponent<Animation>()["Reload_2_3"].wrapMode = WrapMode.Once;
			GetComponent<Animation>()["Reload_3_3"].wrapMode = WrapMode.Once;
		}
		if(type == Type.Rifle){
			GetComponent<Animation>()["Reload"].wrapMode = WrapMode.Once;	
		}
		GetComponent<Animation>()["Fire"].wrapMode = WrapMode.Once;
		GetComponent<Animation>()["Idle"].wrapMode = WrapMode.Once;
		GetComponent<Animation>()["TakeIn"].wrapMode = WrapMode.Once;
		GetComponent<Animation>()["TakeOut"].wrapMode = WrapMode.Once;
		//animation.Play("Idle");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			if(type == Type.Sniper){
				SniperReload();
			}
			if(type == Type.Rifle || type == Type.Automatic){
				RifleReload();
			}
		}
		
		if(type != Type.Automatic && currentClip > 0){
			if(Input.GetMouseButtonDown(0)&&Time.time > nextFire){
				nextFire = Time.time + fireRate;
				GetComponent<Animation>().Rewind("Fire");
				AnimationState fire = GetComponent<Animation>().CrossFadeQueued("Fire");
				fire.speed = animSpeed;
                Shoot();
			}
		}else{
			if(Input.GetMouseButton(0)&&Time.time > nextFire && currentClip > 0){
				nextFire = Time.time + fireRate;
				GetComponent<Animation>().Rewind("Fire");
				GetComponent<Animation>().CrossFade("Fire");
				GetComponent<Animation>()["Fire"].speed = animSpeed;
                Shoot();
			}
		}
	}

    void Shoot()
    {
        currentClip--;
        audio.PlayOneShot(gunShot);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100))
        {
            AlienController alien = hit.transform.GetComponent<AlienController>();
            if (alien != null)
            {
                print("alien hit");
                alien.TakeDamage(damage);
                GameObject tempBlood;
                tempBlood = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(tempBlood, 0.5f);
            }
            else
            {
                //GameObject tempEffect;
                //tempEffect = Instantiate(bulletHit, hit.point, Quaternion.LookRotation(hit.normal));
                //Destroy(tempEffect, 0.5f);
            }
        }
    }

    void RifleReload(){

        if (currentClip == 0)
        {
            if (currentAmmo >= maxClip)
            {
                currentClip = maxClip;
                currentAmmo -= maxClip;
            }
            else
            {
                currentClip = currentAmmo;
                currentAmmo = 0;
            }
        }
        else
        {
            int ammoNeeded = maxClip - currentClip;
            if (currentAmmo >= ammoNeeded)
            {
                currentClip = maxClip;
                currentAmmo -= ammoNeeded;
            }
            else
            {
                currentClip += currentAmmo;
                currentAmmo = 0;
            }
        }

        AnimationState newReload = GetComponent<Animation>().CrossFadeQueued("Reload");
        newReload.speed = animSpeed;
    }
	
	void SniperReload(){
		AnimationState newReload1 = GetComponent<Animation>().CrossFadeQueued("Reload_1_3");
		newReload1.speed = animSpeed;
		//4 is number of bullets to reload
		for(int i = 0; i < 4; i++){
	 		AnimationState newReload2 = GetComponent<Animation>().CrossFadeQueued("Reload_2_3");
			newReload2.speed = animSpeed;
		}
		AnimationState newReload3 = GetComponent<Animation>().CrossFadeQueued("Reload_3_3");
		newReload3.speed = animSpeed;
	}
	
	void TakeIn(){
		GetComponent<Animation>().Play("TakeIn");
		GetComponent<Animation>()["TakeIn"].speed = animSpeed;
	}
	
	void TakeOut(){
		GetComponent<Animation>().CrossFade("TakeOut");
		GetComponent<Animation>()["TakeOut"].speed = animSpeed;
	}
}
