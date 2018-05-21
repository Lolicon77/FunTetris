using UnityEngine;
using System.Collections;


public class LoadPrefabsDelay : MonoBehaviour {

	public float time;

	public GameObject[] Prefabs;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (time);
		foreach (var prefab in Prefabs) {
			Instantiate(prefab);
		}
	}

}
