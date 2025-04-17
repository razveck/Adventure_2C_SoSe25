using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public CinemachineCamera activeCamera;

	public void ChangeCamera(CinemachineCamera newCamera) {
		activeCamera.gameObject.SetActive(false);

		newCamera.gameObject.SetActive(true);
		activeCamera = newCamera;
	}
}
