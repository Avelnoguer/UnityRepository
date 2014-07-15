using UnityEngine;
using System.Collections;

public class ShadownController : MonoBehaviour {

	private Quaternion OrgRotation;
	private Vector3 OrgPosition;
	private Vector3 OrgScale;

	// Use this for initialization
	void Start () {
	
		OrgRotation = transform.rotation;
		OrgPosition = transform.parent.transform.position - transform.position;

	}
	


	void LateUpdate(){
		transform.rotation = OrgRotation;
		transform.position = transform.parent.position - OrgPosition;

	}
}
