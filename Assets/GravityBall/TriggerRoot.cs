using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace{
	public class TriggerRoot : MonoBehaviour{
		private List<Collider> _triggers;


		private void Start(){
			_triggers = GetComponentsInChildren<Collider>().ToList();
			_triggers.ForEach(x => x.OnParticleCollisionAsObservable().Subscribe(other => OnTrigger(x, other)));
		}

		private void OnTrigger(Component origin, Object other){
			var scoreText = origin.GetComponentInChildren<Text>();
			var currentScore = int.Parse(scoreText.text);
			var multiply = int.Parse(origin.name);
			currentScore += 1 * multiply;
			scoreText.text = currentScore.ToString();
		}
	}
}