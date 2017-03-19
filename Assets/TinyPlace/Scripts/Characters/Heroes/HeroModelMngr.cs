using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroModelMngr : MonoBehaviour {

    public Transform trsHead;
    public Transform trsBack;
    public Transform trsBody;
    public Transform trsRightHand;
    public Transform trsLeftHand;

    [HideInInspector]
    public SkinnedMeshRenderer smrBody;

	// Use this for initialization
	void Awake () {
        if (trsBody != null)
            smrBody = trsBody.GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
