using UnityEngine;

namespace DefaultNamespace{
	public class GravityBallActionHandler : MonoBehaviour{
		private ParticleSystem _childParticle;
		[SerializeField] private int boundsMax = 0;

		private int _boundsCount;
		private void Start(){
			_childParticle = GetComponentInChildren<ParticleSystem>();
		}

		private void OnCollisionEnter(Collision collision){
			_boundsCount += 1;
			if(_boundsCount > boundsMax){
				Disperse();
			}
		}

		private void Disperse(){
			_childParticle.transform.SetParent(null);
			_childParticle.Play();
			gameObject.SetActive(false);
		}
	}
}