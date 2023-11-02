using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace{
	public class TriggerRoot : MonoBehaviour{
		private List<Collider> _triggers;
		[SerializeField] private AudioClip scoreClip;
		private AudioSource _audio;


		private void Start(){
			_triggers = GetComponentsInChildren<Collider>().ToList();
			_triggers.ForEach(x => x.OnParticleCollisionAsObservable().Subscribe(other => OnTrigger(x, other)));
			_audio = gameObject.AddComponent<AudioSource>();
		}

		private void OnTrigger(Component origin, Object other){
			_audio.PlayOneShot(scoreClip);
			var scoreText = origin.GetComponentInChildren<Text>();
			var currentScore = int.Parse(scoreText.text);
			var multiply = int.Parse(origin.name);
			currentScore += 1 * multiply;
			scoreText.text = currentScore.ToString();
		}
	}
}