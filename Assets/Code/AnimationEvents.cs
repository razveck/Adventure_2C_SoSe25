using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	private EventInstance footstepInstance;
	public EventReference footstepRef;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//alternative zu EventReference
		//footstepInstance = RuntimeManager.CreateInstance("event:/SFX/Footsteps/SFX_Footsteps");

		footstepInstance = RuntimeManager.CreateInstance(footstepRef);
	}

	public void Footstep(){
		footstepInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
		footstepInstance.start();
	}
}
