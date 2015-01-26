//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;


public class HandTracker : MonoBehaviour
{
	public Material BoneMaterial;
	public GameObject BodySourceManager;

	public bool isGrabbing = false;
	public Vector3 rightHandPosition;
	
	private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
	private BodySourceManager _BodyManager;
	
	private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
	{
/*		{ Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
		{ Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
		{ Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
		{ Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
		
		{ Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
		{ Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
		{ Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
		{ Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
		
		{ Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
		{ Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
		{ Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
		{ Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
		{ Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
		{ Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
*/		
		{ Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
		{ Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
		{ Kinect.JointType.HandRight, Kinect.JointType.WristRight },
		{ Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
		{ Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
		{ Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
/*		
		{ Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
		{ Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
		{ Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
		{ Kinect.JointType.Neck, Kinect.JointType.Head },
*/	};
	
	void Update () 
	{
		if (BodySourceManager == null)
		{
			return;
		}
		
		_BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
		if (_BodyManager == null)
		{
			return;
		}
		
		Kinect.Body[] data = _BodyManager.GetData();
		if (data == null)
		{
			return;
		}
		
		List<ulong> trackedIds = new List<ulong>();
		foreach(var body in data)
		{
			if (body == null)
			{
				continue;
			}
			
			if(body.IsTracked)
			{
				trackedIds.Add (body.TrackingId);
			}
		}
		
		List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
		
		// First delete untracked bodies
		foreach(ulong trackingId in knownIds)
		{
			if(!trackedIds.Contains(trackingId))
			{
				Destroy(_Bodies[trackingId]);
				_Bodies.Remove(trackingId);
			}
		}
		
		foreach(var body in data)
		{
			if (body == null)
			{
				continue;
			}
			
			if(body.IsTracked)
			{
				if(!_Bodies.ContainsKey(body.TrackingId))
				{
//					if(body.HandRightState == Kinect.HandState.Closed)
						_Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId, body);
				}
				
				RefreshBodyObject(body, _Bodies[body.TrackingId]);
			}
		}


	}
	
	private GameObject CreateBodyObject(ulong id, Kinect.Body bodyData) //need to correlate id with body
	{
//		print ("asdf");

		GameObject body = new GameObject("Body:" + id);
/*		GameObject objType;

		if(bodyData.HandRightState == Kinect.HandState.Closed)
		{
			print (bodyData.HandRightState + " if");	
			objType = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			
		}
		else if (bodyData.HandRightState == Kinect.HandState.Open)
		{
			print (bodyData.HandRightState + " else");
			objType = GameObject.CreatePrimitive(PrimitiveType.Cube);
			
		}else{
			//print (bodyData.HandRightState + " else");
			objType = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		}
*/
		for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
		{
//			print ("start");
//			GameObject jointObj = objType;

			//GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//LineRenderer lr = jointObj.AddComponent<LineRenderer>();
			//lr.SetVertexCount(2);
			//lr.material = BoneMaterial;
			//lr.SetWidth(0.05f, 0.05f);

			//jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			//jointObj.name = jt.ToString();
			//jointObj.transform.parent = body.transform;

//			print ("jointObj.name: " + jointObj.name);
//			print ("jointObj.transfor.parent: " + jointObj.transform.partent);

		}
		
		return body;
	}
	
	private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
	{
		if(body.HandRightState == Kinect.HandState.Closed)
		{
//			print (body.HandRightState + " if");			
		}
		else if (body.HandRightState == Kinect.HandState.Open)
		{
//			print (body.HandRightState + " else if");		
		}
		else
		{
//			print (body.HandRightState + " else");
		}


		for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
		{

//			print (jt);
//			print (body.HandRightState);
//			Console.WriteLine("spam");
//			if(jt == "HandRight" || "HandTipRight" || "ThumbRight" || "WristRight" || "ElbowRight" || "ShoulderRight" || "SpineShoulder" )
			if(jt == Kinect.JointType.HandTipRight //|| 
			   //jt == Kinect.JointType.HandTipRight || 
			   //jt == Kinect.JointType.WristRight || 
			   //jt == Kinect.JointType.ThumbRight
			   )
			{

				Kinect.Joint sourceJoint = body.Joints[jt];
				Kinect.Joint? targetJoint = null;
			
				if(_BoneMap.ContainsKey(jt))
				{
					targetJoint = body.Joints[_BoneMap[jt]];
				}
			
				//Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
				//jointObj.localPosition = GetVector3FromJoint(sourceJoint);

//				print (jointObj);
			
				//LineRenderer lr = jointObj.GetComponent<LineRenderer>();
				if(targetJoint.HasValue)
				{

					rightHandPosition = GetVector3FromJoint(targetJoint.Value);

					//set hand position on screen
					
					var handObjects = GameObject.FindGameObjectsWithTag("HandClosed");
					var handClosed = handObjects[0];
					handObjects = GameObject.FindGameObjectsWithTag("Hand");
					var handOpen = handObjects[0];

					if(isGrabbing){
						handObjects = GameObject.FindGameObjectsWithTag("HandClosed");
						handClosed.transform.localPosition = rightHandPosition;
					}else{
						handObjects = GameObject.FindGameObjectsWithTag("Hand");
						handOpen.transform.localPosition = rightHandPosition;
					}

					//lr.SetPosition(0, jointObj.localPosition);
					//lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));

					if(body.HandRightState == Kinect.HandState.Open)
					{
						if(isGrabbing)
						{
							isGrabbing = false;
							print ("Hand released");
							print ("Hand x:" + rightHandPosition.x + ", y:" + rightHandPosition.y + ", z:" + rightHandPosition.z);
							handClosed.transform.localPosition = new Vector3(-9999,-9999,-9999);
						}
//						print (body.HandRightState + " if");	
						//lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
//						bodyObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);

					}
					else if (body.HandRightState == Kinect.HandState.Closed)
					{
						if(!isGrabbing)
						{
							isGrabbing = true;
							print ("Hand grabbed");
							print ("Hand x:" + rightHandPosition.x + ", y:" + rightHandPosition.y + ", z:" + rightHandPosition.z);
							handOpen.transform.localPosition = new Vector3(-9999,-9999,-9999);
							
							var grabObjects = GameObject.FindGameObjectsWithTag("GrabTimer");
							var grabTimer = grabObjects[0].GetComponent<UnityEngine.UI.Slider>();

							//var grabTimer = grabObjects[0];
							grabTimer.value = 0.5f;
							//Debug.Log ("asdf");


						}
						//lr.SetColors(new Color(1, 1, 1, 0), new Color(1, 1, 1, 0));
//						jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
					}
					else
					{
//						print (body.HandRightState + " else");
//						lr.SetColors( new Color(1, 1, 1, 0), new Color(1, 1, 1, 0));
						//lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
					}

				}
				else
				{
					//lr.enabled = false;
				}

			}
		}
	}
	
	private static Color GetColorForState(Kinect.TrackingState state)
	{
		switch (state)
		{
		case Kinect.TrackingState.Tracked:
			return Color.green;
			
		case Kinect.TrackingState.Inferred:
			return Color.red;
			
		default:
			return Color.black;
		}
	}
	
	public static Vector3 GetVector3FromJoint(Kinect.Joint joint)
	{
		return new Vector3(joint.Position.X * 10 + 100, joint.Position.Y * 20 + 6.5f, joint.Position.Z * -10 + 43);
	}
}


