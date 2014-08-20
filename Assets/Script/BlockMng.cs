using UnityEngine;
using System.Collections;

public class BlockMng : MonoBehaviour {
	public int[] _BlockTypes = new int[1];

	// Use this for initialization
	void Start () {
		MakeBlocks();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MakeBlocks( ) {
		for(int i = 0; i < _BlockTypes.Length; i++) {
			GameObject obj = (Instantiate(Resources.Load<GameObject>("Block")) as GameObject);
			obj.SetActive( true );
			obj.transform.position = new Vector3(i * 2.0f, 0.0f, 0.0f);
			obj.transform.parent = transform;
			obj.GetComponent<BlockCtrl>().ChangeBlock(_BlockTypes[i]);
		}
	}
}
