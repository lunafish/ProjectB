using UnityEngine;
using System.Collections;

public class BlockCtrl : MonoBehaviour {
	public ArrayList _blocks = new ArrayList();
	public int _blockType = 0;

	// Use this for initialization
	void Start () {
		//MakeBlockList();
		//ChangeBlock( _blockType );
	}

	// Update is called once per frame
	void Update () {
	
	}

	// Get Child object
	void MakeBlockList( ) { 
		Transform[] trans = GetComponentsInChildren<Transform>(); // get All Children transform
		foreach( Transform data in trans ) {
			if(data.gameObject.tag.CompareTo("block") == 0) {
				_blocks.Add (data.gameObject); // get gameobject at transform
//				Debug.Log(data.gameObject);
			}
		}
	}

	// change block
	public void ChangeBlock( int type ) {
		_blockType = type;

		for(int i = 0; i < _blocks.Count; i++) {
			GameObject obj = _blocks[i] as GameObject;
			if(i == _blockType) {
				obj.SetActive(true);
			} else {
				obj.SetActive(false);
			}
		}
	}
}
