using UnityEngine;

namespace DefaultNamespace{
	public class GravityBallActionHandler : MonoBehaviour{
		private ParticleSystem _childParticle;
		[SerializeField] private int boundsMax = 0;
		[SerializeField] private AudioClip bounceClip;
		[SerializeField] private AudioClip disperseClip;


		private int _boundsCount;
		private AudioSource _audio;

		private void Start(){
			_childParticle = GetComponentInChildren<ParticleSystem>();
			_audio = _childParticle.gameObject.AddComponent<AudioSource>();
		}

		private void OnCollisionEnter(Collision collision){
			_audio.PlayOneShot(bounceClip);
			_boundsCount += 1;
			if(_boundsCount > boundsMax){
				Disperse();
			}
		}

		private void Disperse(){
			_audio.PlayOneShot(disperseClip);
			_childParticle.transform.SetParent(null);
			_childParticle.Play();
			gameObject.SetActive(false);
			Destroy(gameObject, 3f);
		}
	}
}