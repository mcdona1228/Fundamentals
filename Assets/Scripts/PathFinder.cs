using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : Kinematic
{
    Seek myMoveType;
    Face mySeekRotationType;
    LookWhereGoing myFleeRotateType;

    public GameObject myTarget2;
    public GameObject myTarget3;
    public GameObject myTarget4;
    public GameObject myTarget5;
    public GameObject myTarget6;

    public bool flee = false;

    void Start()
    {
        myMoveType = new Seek();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.target = myTarget2;
        myMoveType.target = myTarget3;
        myMoveType.target = myTarget4;
        myMoveType.target = myTarget5;
        myMoveType.target = myTarget6;
        myMoveType.flee = flee;

        mySeekRotationType = new Face();
        mySeekRotationType.character = this;
        mySeekRotationType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotationType.getSteering().angular;
        base.Update();
    }
}
