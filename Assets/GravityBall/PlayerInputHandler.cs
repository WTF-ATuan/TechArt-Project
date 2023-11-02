using UnityEngine;

public class PlayerInputHandler : MonoBehaviour{
	[SerializeField] private LayerMask detectLayer;
	[SerializeField] private GameObject preBall;
	[SerializeField] private float throwForce = 5;
	[SerializeField] private AudioClip throwClip;


	private Camera _camera;
	private AudioSource _audio;

	private void Start(){
		_camera = Camera.main;
		_audio = gameObject.AddComponent<AudioSource>();
	}

	private void Update(){
		DetectInput();
	}

	private void DetectInput(){
		var mousePosition = Input.mousePosition;
		mousePosition.z = 10;
		mousePosition = _camera.ScreenToWorldPoint(mousePosition);
		var cameraPosition = _camera.transform.position;

		if(!Input.GetMouseButtonDown(0)) return;
		var ray = new Ray(cameraPosition, mousePosition - cameraPosition);
		if(Physics.Raycast(ray, out var hit, 100, detectLayer)){
			PlaceGravityBall(hit.point);
		}
	}

	private void PlaceGravityBall(Vector3 placePoint){
		placePoint.y = Random.Range(3f, 5f);
		var cameraPosition = _camera.transform.position;
		var ballRigid = Instantiate(preBall, cameraPosition, Quaternion.identity).GetComponent<Rigidbody>();
		ballRigid.AddForce((placePoint - cameraPosition) + _camera.transform.forward * throwForce, ForceMode.Impulse);
		_audio.PlayOneShot(throwClip);
	}
}