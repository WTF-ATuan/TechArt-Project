using UnityEngine;

namespace DefaultNamespace{
	public class GravityBallActionHandler : MonoBehaviour{
		private ParticleSystem _childParticle;

		private void Start(){
			_childParticle = GetComponentInChildren<ParticleSystem>();
		}

		private void OnCollisionEnter(Collision collision){
			_childParticle.transform.SetParent(null);
			_childParticle.Play();
			gameObject.SetActive(false);
		}
	}
}