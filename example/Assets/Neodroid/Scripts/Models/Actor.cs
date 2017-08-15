﻿
using MsgPack.Serialization;
using Neodroid.Utilities;
using System.Collections.Generic;
using UnityEngine;
using Neodroid.Models.Motors;

namespace Neodroid.Models {
  public class Actor : MonoBehaviour, HasRegister<Motor> {
    public float[] _position;
    public float[] _rotation;

    //[MessagePackKnownCollectionItemType("SingleAxisMotor", typeof(SingleAxisMotor))]
    //[MessagePackKnownCollectionItemType("Motor", typeof(Motor))]
    [MessagePackRuntimeType]
    public Dictionary<string, Motor> _motors;

    public Actor() { }

    [MessagePackIgnore]
    public NeodroidAgent _agent_game_object;
    [MessagePackIgnore]
    public bool _debug = false;

    private void Start() {
      if (_motors == null)
        _motors = new Dictionary<string, Motor>();
      NeodroidFunctions.MaybeRegisterComponent(_agent_game_object, this);
    }

    private void Update() {
      _position = new float[] { transform.position.x, transform.position.y, transform.position.z };
      _rotation = new float[] { transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w };
    }

    public Dictionary<string, Motor> GetMotors() {
      return _motors;
    }

    public void AddMotor(Motor motor) {
      if (_motors == null)
        _motors = new Dictionary<string, Motor>();
      if (_debug) Debug.Log("Actor " + name + " has motor " + motor);
      _motors.Add(motor._motor_identifier, motor);
    }

    public void Register(Motor obj) {
      AddMotor(obj);
    }
  }
}
