using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour {
	
    private static float FUSE_TIME_IN_S = 3;
	private static float CLEANUP_AFTER_N_S = 2;

	void Start()
	{
		StartCoroutine(CountdownToExplosion());
	}

	void OnDestroy()
	{
		Debug.Log("Destroyed");
	}

	private IEnumerator CountdownToExplosion()
	{
		yield return new WaitForSeconds(FUSE_TIME_IN_S);

		Explode();
		yield return new WaitForSeconds(CLEANUP_AFTER_N_S);

		Destroy(this.gameObject);
	}

	private void Explode()
	{
		var explosionObj = this.transform.Find("ExplosionEffect").gameObject;
		explosionObj.SetActive(true);
	}
}
