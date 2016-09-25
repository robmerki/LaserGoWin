using UnityEngine;
using System.Collections;

public class TreasureRewardAnimator : MonoBehaviour {
	[System.NonSerialized]
	public TreasureContents contents;
//	[System.NonSerialized]
//	public Vector3 accel;
//	[System.NonSerialized]
//	public Vector3 velocity;

	// Use this for initialization
	void Start () {
	
	}

	//public void set(TreasureContents contentsIn, Vector3 p1, Vector3 p3, float t) {
	public void set(TreasureContents contentsIn) {
		// set the reward contents
		contents = contentsIn;
		// calculate accel and velocity
		//Vector3 vector_to_p3 = p3 - p1;
		//Vector3 p2 = (vector_to_p3.z == 0) ? new Vector3 (0,0,1) : new Vector3 (-vector_to_p3.x, -vector_to_p3.y, (vector_to_p3.x * vector_to_p3.x + vector_to_p3.y * vector_to_p3.y) / vector_to_p3.z);
		//Vector3.Normalize (p2);
		//p2 = p2 * vector_to_p3.magnitude;
		//p2 = ((p1 - p3) / 2) + p2;
//		Vector3 midpoint = (p3+p1) / 2;
//		float scale = 2.0f;
//		Vector3 p2 = (Vector3.up * 3.0f) + new Vector3(Random.Range(-scale,scale),Random.Range(-scale,scale),Random.Range(-scale,scale));
//		GameObject.Instantiate (Resources.Load ("tester1"), p1, Quaternion.identity);
//		GameObject.Instantiate (Resources.Load ("tester2"), p2, Quaternion.identity);
//		GameObject.Instantiate (Resources.Load ("tester3"), p3, Quaternion.identity);
//		// so we now have p1,p2,p3 that are start middle and end points of parabola
//		float t1 = t; float t2 = t*2;
//		float ax = p3.x + p2.x - (p3.x * t1 / t2) - (p2.x * t2 / t1);
//		float vx = (p2.x / t1) - p1.x - (ax * t1);
//		float ay = p3.y + p2.y - (p3.y * t1 / t2) - (p2.y * t2 / t1);
//		float vy = (p2.y / t1) - p1.y - (ay * t1);
//		float az = p3.z + p2.z - (p3.z * t1 / t2) - (p2.z * t2 / t1);
//		float vz = (p2.z / t1) - p1.z - (az * t1);
//		accel = new Vector3 (ax, ay, az);
//		velocity = new Vector3 (vx, vy, vz);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
