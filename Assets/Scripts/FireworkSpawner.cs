using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour {

	private static float FIREWORK_GENERATION_PERIOD_IN_S = 2;
	private static float FIREWORK_START_HEIGHT_OFFSET_IN_M = 1;

	public float fireworkStartVelocity = 50;

	void Start()
	{
		StartCoroutine(SpawnFireworks());
	}

	private IEnumerator SpawnFireworks()
	{
		while (true)
		{
			CreateFirework();

			yield return new WaitForSeconds(FIREWORK_GENERATION_PERIOD_IN_S);
		}
	}

	private void CreateFirework()
	{
		var fireworkPrototype = Resources.Load("Firework", typeof(GameObject)) as GameObject;

		var spawnerPos = this.transform.position;
		var aboveSpawnerPos = new Vector3(spawnerPos.x, spawnerPos.y + FIREWORK_START_HEIGHT_OFFSET_IN_M, spawnerPos.z);

		var newFirework = GameObject.Instantiate(fireworkPrototype, aboveSpawnerPos, Quaternion.identity);

		var fireworkRb = newFirework.GetComponent<Rigidbody>();
		fireworkRb.AddForce(Vector3.up * fireworkStartVelocity, ForceMode.VelocityChange);
	}
}
