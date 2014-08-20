using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public GameObject _mesh;
	public Camera _camera;
	public Vector3 _camPos = new Vector3(3.0f, 1.0f, -6.0f);
	public int _JumpPower = 6;

	private bool _isJump = false;
	private int _isMove = 0;

	// for mouse
	private Vector3 _mousePosOrg; // first mouse position

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMng._isStart) {
			UpdateKey();
			UpdateTouch( );
			UpdateCamera();
		}
	}

	public void onClickJump(){
		if(_isJump == false) {
			rigidbody.velocity = new Vector3(0, _JumpPower, 0);
			_isJump = true;
		}
	}

	void UpdateKey( ) {
		if(Input.GetKeyDown(KeyCode.UpArrow) ) {
			if(_isJump == false) {
				rigidbody.velocity = new Vector3(0, _JumpPower, 0);
				_isJump = true;
			}
		}
		else if(Input.GetKey(KeyCode.LeftArrow) ) {
			transform.Translate(-0.1f, 0.0f, 0.0f);
			_mesh.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
		}
		else if(Input.GetKey(KeyCode.RightArrow) ) {
			transform.Translate(0.1f, 0.0f, 0.0f);
			_mesh.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
		}
	}

	void UpdateTouch( ) {
		if(Input.GetMouseButtonDown(0)) {
			_mousePosOrg = Input.mousePosition;
			Debug.Log(_mousePosOrg);
		} else if(Input.GetMouseButton(0) ) {
			Vector3 dir = Input.mousePosition - _mousePosOrg;

			if(dir.y > 2.0f) {
				if(_isJump == false) {
					rigidbody.velocity = new Vector3(0, _JumpPower, 0);
					_isJump = true;
				}
			} else {
				if(dir.x < -2.0f) {
					_isMove = 1;
				} else if(dir.x > 2.0f) {
					_isMove = 2;
				}

				if(_isMove == 1) {
					transform.Translate(-0.1f, 0.0f, 0.0f);
					_mesh.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
				} else if(_isMove == 2) {
					transform.Translate(0.1f, 0.0f, 0.0f);
					_mesh.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
				}
			}
			_mousePosOrg = Input.mousePosition;
		} else if(Input.GetMouseButtonUp(0)) {
			_isMove = 0;
		}
	}

	void UpdateCamera( ) {
		_camera.transform.position = new Vector3(this.transform.position.x + _camPos.x, _camPos.y, this.transform.position.z + _camPos.z);
	}

	void OnCollisionEnter(Collision collision)
	{
		_isJump = false;
		Debug.Log ("OnCollisionEnter ");
	}
	
}
