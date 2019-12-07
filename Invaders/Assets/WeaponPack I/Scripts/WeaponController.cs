using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	
	public enum Type {Sniper, Rifle, Automatic, Knife}
	public Type type;
	
	public float animSpeed = 1;
	public float fireRate = 0.1f;
	float nextFire = 0;
	
	// Use this for initialization
	void Awake () {
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
		
		if(type != Type.Automatic){
			if(Input.GetMouseButtonDown(0)&&Time.time > nextFire){
				nextFire = Time.time + fireRate;
				GetComponent<Animation>().Rewind("Fire");
				AnimationState fire = GetComponent<Animation>().CrossFadeQueued("Fire");
				fire.speed = animSpeed;
			}
		}else{
			if(Input.GetMouseButton(0)&&Time.time > nextFire){
				nextFire = Time.time + fireRate;
				GetComponent<Animation>().Rewind("Fire");
				GetComponent<Animation>().CrossFade("Fire");
				GetComponent<Animation>()["Fire"].speed = animSpeed;
			}
		}
	}
	
	void RifleReload(){
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
