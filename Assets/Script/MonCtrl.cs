using UnityEngine;
using System.Collections;

public class MonCtrl : MonoBehaviour {
	private Vector3 _PosOrg;
	private Vector3 _PosTarget;
	private bool _isPatrol = false;
	private float _MoveRange = 1.0f;

	private GameMng _gamemng = null;

	// Use this for initialization
	void Start () {
		_isPatrol = false;
		_gamemng = GameObject.FindGameObjectWithTag("GAMEMNG").GetComponent<GameMng>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMng._isStart){
			if(_isPatrol) {
				Patrol();
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.CompareTo("Player") == 0) {
			Destroy(other.gameObject);
		} else if(other.gameObject.tag.CompareTo("block") == 0) {
			if(_isPatrol == false) {
				_isPatrol = true;
				_PosOrg = transform.position;
				_PosTarget = _PosOrg;
				_PosTarget.x -= _MoveRange;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Destroy(this.gameObject);
		_gamemng.AddScore( 500 ); // add monster score
	}

	void Patrol( ) {
		float len = _PosTarget.x - transform.position.x;

		/*
		float dir = -1.0f;
		if(len < 0.0f)
			dir = -1.0f;
		else 
			dir = 1.0f;

		float speed = 0.025f;

		if(Mathf.Abs(len) > 0.1f) {
			transform.position += new Vector3( speed * dir, 0.0f, 0.0f);
		} else {
			_PosTarget = _PosOrg;
			_PosTarget.x -= _MoveRange * dir;
		}
		*/

		float speed = 0.025f;
		if(Mathf.Abs (len) > 0.1f) {
			if(len < 0.0f) {
				transform.position -= new Vector3(speed, 0.0f, 0.0f);
			} else {  
				transform.position += new Vector3(speed, 0.0f, 0.0f);
			}
		} else {
			_PosTarget = _PosOrg;
			if(len < 0.0f) {
				_PosTarget.x += _MoveRange;
			} else {
				_PosTarget.x -= _MoveRange;
			}
		}
	}
}
