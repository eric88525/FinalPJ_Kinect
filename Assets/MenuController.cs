using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using Joint = Windows.Kinect.Joint;
// 控制menu
public class MenuController : MonoBehaviour
{
    public BodySourceManager mbodysourceManager;
    //public GameObject dot;
    public Transform Mouselocation;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<JointType> _joints = new List<JointType>
    {
        //JointType.HandLeft,
        JointType.HandRight,
        //JointType.Head
       //JointType.SpineMid
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Get kinect data
        Body[] data = mbodysourceManager.GetData();
        if (data == null) return;
        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if (body == null) continue;
            if (body.IsTracked)
                trackedIds.Add(body.TrackingId);
        }
        #endregion
        #region delete kinect bodies
        List<ulong> knowIds = new List<ulong>(mBodies.Keys);
        foreach (ulong trackedid in knowIds)
        {
            if (!trackedIds.Contains(trackedid))
            {
                Destroy(mBodies[trackedid]);
                mBodies.Remove(trackedid);
            }
        }
        #endregion
        #region create body
        foreach (var body in data)
        {

            if (body == null) continue;
            if (body.IsTracked)
            {
                if (body.HandRightState == HandState.Closed)
                {
                    PlayerPrefs.SetInt("HangrightState", 1);
                    Debug.Log("close");
                }
                else
                {
                    PlayerPrefs.SetInt("HangrightState", 0);
                }
                foreach (JointType joint in _joints)
                {
                    Joint sourcejoint = body.Joints[joint];
                    Vector3 targetpos = getVec3fromjoint(sourcejoint);
                    targetpos.z = 0;

                    Mouselocation.position = targetpos;
                }

                /* if (!mBodies.ContainsKey(body.TrackingId))
                 {
                     mBodies[body.TrackingId] = CreateBodyobj(body.TrackingId);
                 }
                 UpdateBodyobj(body,mBodies[body.TrackingId]);*/
            }
        }



        #endregion
    }

    private void UpdateBodyobj(Body body, GameObject bodyObject)
    {
        foreach (JointType joint in _joints)
        {

            //if (body.HandRightState == HandState.Closed)
            //{
            //    PlayerPrefs.SetInt("RightHandstate", 1);
            //}
            //else
            //{
            //    PlayerPrefs.SetInt("RightHandstate", 0);
            //}
            Joint sourcejoint = body.Joints[joint];
            Vector3 targetpos = getVec3fromjoint(sourcejoint);
            targetpos.z = 0;
            Transform jointobj = bodyObject.transform.Find(joint.ToString());
            jointobj.position = targetpos;
        }
    }

    private Vector3 getVec3fromjoint(Joint joint)
    {


        return new Vector3(joint.Position.X * 1920, joint.Position.Y * 1080, -10);


    }

    private GameObject CreateBodyobj(ulong trackingId)
    {
        GameObject body = new GameObject("Body" + trackingId);
        //foreach (JointType joint in _joints)
        //{
        //    GameObject newDot = Instantiate(dot);
        //    newDot.name = joint.ToString();

        //    newDot.transform.parent = body.transform;

        //}


        return body;
    }
}
