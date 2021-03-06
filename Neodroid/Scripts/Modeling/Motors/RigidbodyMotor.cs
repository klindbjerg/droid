﻿using Neodroid.Messaging.Messages;
using UnityEngine;
using Neodroid.Utilities;

namespace Neodroid.Motors {

  [RequireComponent (typeof(Rigidbody))]
  public class RigidbodyMotor : Motor {
    public Axis _axis_of_motion;
    Rigidbody _rigidbody;

    private void Start () {
      _rigidbody = GetComponent<Rigidbody> ();
      RegisterComponent ();
    }

    public override void ApplyMotion (MotorMotion motion) {
      if (!_bidirectional && motion.Strength < 0) {
        Debug.Log ("Motor is not bi-directional. It does not accept negative input.");
        return; // Do nothing
      }
      if (_debug)
        Debug.Log ("Applying " + motion.ToString () + " To " + name);
      switch (_axis_of_motion) {
      case Axis.X:
        _rigidbody.AddForce (Vector3.left * motion.Strength);
        break;
      case Axis.Y:
        _rigidbody.AddForce (Vector3.up * motion.Strength);
        break;
      case Axis.Z:
        _rigidbody.AddForce (Vector3.forward * motion.Strength);
        break;
      case Axis.RotX:
        _rigidbody.AddTorque (Vector3.left * motion.Strength);
        break;
      case Axis.RotY:
        _rigidbody.AddTorque (Vector3.up * motion.Strength);
        break;
      case Axis.RotZ:
        _rigidbody.AddTorque (Vector3.forward * motion.Strength);
        break;
      default:
        break;
      }
      _energy_spend_since_reset += _energy_cost * motion.Strength;
    }

    //GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * motion._strength, transform.position);
    //GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * motion._strength);

    public override string GetMotorIdentifier () {
      return name + "Rigidbody" + _axis_of_motion.ToString ();
    }
  }
}
