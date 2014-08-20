using UnityEngine;
using System.Collections;

public class DoorCtrl : MonoBehaviour {

	private GameMng _gamemng = null;

	// Use this for initialization
	void Start () {
		_gamemng = GameObject.FindGameObjectWithTag("GAMEMNG").GetComponent<GameMng>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		_gamemng.ClearGame();
	}
}
