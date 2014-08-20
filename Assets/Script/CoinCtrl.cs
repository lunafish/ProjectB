using UnityEngine;
using System.Collections;

public class CoinCtrl : MonoBehaviour {
	private GameMng _gamemng = null;

	// Use this for initialization
	void Start () {
		_gamemng = GameObject.FindGameObjectWithTag("GAMEMNG").GetComponent<GameMng>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		_gamemng.AddScore( 100 ); // add coin score
		Destroy(this.gameObject);
	}
}
