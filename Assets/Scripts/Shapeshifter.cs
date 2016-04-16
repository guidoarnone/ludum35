using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shapeshifter : MonoBehaviour {

	private SkinnedMeshRenderer skinnedMeshRenderer;
	private Mesh skinnedMesh;
	private int blendShapeCount;

	private List<Transition> transitionList;
	public bool onTransition = false;
	private bool sway = false;

	void Start () {
		this.skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer> ();
		this.skinnedMesh = skinnedMeshRenderer.sharedMesh;
		this.blendShapeCount = skinnedMesh.blendShapeCount;
		if (this.blendShapeCount == 0) {
			this.enabled = false;
		}
		this.transitionList = new List<Transition>();
	}
	

	void Update () {
		if (this.onTransition) {
			this.checkTransitionsAndFinish();
			this.updateTransitions();
		}
	}

	public void startTransition(Transition transition) {
		if(!this.onTransition) {
			this.onTransition = true;
			this.clearTransitions();
			this.transitionList.Add(transition);
		}
	}

	public void startTransition(List<Transition> transitions) {
		if(!this.onTransition) {
			this.onTransition = true;
			this.clearTransitions();
			for (int i = 0; i < transitions.Count; i++) {
				this.transitionList.Add(transitions [i]);
			}
		}
	}

	public void startSwayTransition(List<Transition> transitions) {
		this.sway = true;
		this.startTransition (transitions);
	}

	public void setShapeshift(int index, float s) {
		this.skinnedMeshRenderer.SetBlendShapeWeight (index, s);
	}

	public void setShapeshift(List<float> values) {
		for(int v = 0; v < values.Count; v++) {
			this.skinnedMeshRenderer.SetBlendShapeWeight (v, values [v]);
		}
	}

	private void createTransitionList() {
		for(int i = 0; i < this.blendShapeCount; i++) {
			transitionList.Add (new Transition ());
		}
	}

	private void clearTransitions() {
		this.transitionList = new List<Transition> ();
	}

	private void checkTransitionsAndFinish() {
		bool finished = true;
		foreach (Transition t in this.transitionList) {
			if (t.getCurrentValue () != t.getFinalValue ()) {
				finished = false;
			}
		}
		if (finished) {
			if (sway) {
				this.invert ();
			} else {
				this.onTransition = false;
				this.clearTransitions ();
			}
		}
	}

	private void updateTransitions() {
		for (int t = 0; t < transitionList.Count; t++) {
			float nextValue = transitionList [t].getCurrentValue () + transitionList [t].getRate () * Time.deltaTime;
			if (transitionList[t].getRate() > 0) {
				nextValue = Mathf.Min(nextValue, transitionList [t].getFinalValue ());
			} else if(transitionList[t].getRate() < 0) {
				nextValue = Mathf.Max (nextValue, transitionList [t].getFinalValue ());
			}
			this.setShapeshift (t, nextValue);
			transitionList [t].setCurrentValue (nextValue);
		}	
	}

	public Transition getDummyTransition(int blendShapeIndex) {
		float defaultValue = this.skinnedMeshRenderer.GetBlendShapeWeight (blendShapeIndex);
		return new Transition (defaultValue,0f,defaultValue);
	}
		
	public Transition makeTransitionFromBlendShape(int blendShapeIndex, float rate, float finalValue) {
		float initialValue = this.skinnedMeshRenderer.GetBlendShapeWeight (blendShapeIndex);
		return new Transition (initialValue, rate, finalValue);
	}

	public List<Transition> makeTransitionsFromCurrentState(List<float> rates, List<float> finalValues) {
		List<Transition> transitions = new List<Transition> ();
		for(int i = 0; i < this.blendShapeCount; i++) {
			transitions.Add (this.makeTransitionFromBlendShape(i, rates[i], finalValues[i]));
		}
		return transitions;
	}

	public void invert() {
		for (int t = 0; t < transitionList.Count; t++) {
			transitionList [t].setRate (transitionList [t].getRate () * -1);
			float auxInit = transitionList [t].getInitialValue ();
			transitionList [t].setInitialValue (transitionList [t].getFinalValue ());
			transitionList [t].setFinalValue (auxInit);
		}
	}
		
}
