using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private void Update()
	{
		float y = Input.GetAxis("Mouse X") * this.rotateSpeed;
		float num = Input.GetAxis("Mouse Y") * this.rotateSpeed;
		if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
		{
			base.transform.eulerAngles -= new Vector3(-num, y, 0f);
		}
	}
	public float rotateSpeed;
}
