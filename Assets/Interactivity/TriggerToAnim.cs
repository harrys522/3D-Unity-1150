using UnityEngine;
using System.Collections;

public class TriggerToAnim : MonoBehaviour {

	public Animator animator;
	public LayerMask layerMask = -1;
	public string enterTriggerName = "Enter";
	public string exitTriggerName = "Exit";
	public string occupiedBoolName = "Occupied";
	private bool isOccupied = false;

	public void FixedUpdate() {
		animator.SetBool(occupiedBoolName, isOccupied);
		isOccupied = false;
	}

	private bool InMask(Collider collider) {
		return ((layerMask.value & (1 << collider.gameObject.layer)) > 0);
	}

	public void OnTriggerEnter(Collider collider) {
		if (InMask(collider)) {
			animator.SetTrigger(enterTriggerName);
		}
	}

	public void OnTriggerExit(Collider collider) {
		if (InMask(collider)) {
			animator.SetTrigger(exitTriggerName);
		}
	}

	public void OnTriggerStay(Collider collider) {
		if (InMask(collider)) {
			isOccupied = true;
		}
	}

}
