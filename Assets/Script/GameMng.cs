using UnityEngine;
using System.Collections;

public class GameMng : MonoBehaviour {
	public static bool _isStart = false; // is start game?

	public GameObject _btnStart;
	public GameObject _btnJump;
	public UILabel _countLabel;
	public GameObject _clearLabel;

	public UICamera _uiCamera;

	private int _score = 0;

	// Use this for initialization
	void Start () {
		_btnJump.SetActive(false);
		_clearLabel.SetActive(false);
		_countLabel.text = _score.ToString();

		// test
		Debug.Log(_uiCamera.collider2D);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClearGame(){
		_clearLabel.SetActive(true);
		_btnJump.SetActive(false);
		_isStart = false;
	}

	public void OnClickStart() {
		_btnStart.SetActive(false);
		_isStart = true;
		_btnJump.SetActive(true);
	}

	public void AddScore( int value ) {
		_score += value;
		_countLabel.text = _score.ToString();
	}
}
