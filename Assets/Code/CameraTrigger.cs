using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public CameraManager manager;
	public CinemachineCamera camera;

	private void OnTriggerEnter(Collider other) {
		manager.ChangeCamera(camera);
	}
}
