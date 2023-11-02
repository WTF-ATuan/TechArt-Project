using UnityEngine;

public class PlayerInputHandler : MonoBehaviour{
	[SerializeField] private LayerMask detectLayer;
	[SerializeField] private GameObject preBall;
	
	private Camera _camera;
	
	private void Start(){
		_camera = Camera.main;
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
		Instantiate(preBall, placePoint, Quaternion.identity);
	}
}