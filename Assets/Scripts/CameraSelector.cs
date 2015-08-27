using UnityEngine;

public class CameraSelector : MonoBehaviour
{
	// Public fields, set in the inspector we can access
	// them through the singleton instance
	public Camera[] cameraArray;

	// Static singleton property
	public static CameraSelector instance { get; private set; }

	// Instance methods, these method can be accesed through the singleton instance
	public void setCamera(int i)
	{
		foreach (Camera camera in cameraArray) {
			camera.enabled = false;
		}
		cameraArray [i].enabled = true;
	}
	
	void Awake()
	{
		// Save a reference to the component as our singleton instance
		instance = this;
	}
}