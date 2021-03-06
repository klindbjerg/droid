﻿using Neodroid.Messaging.Messages;
using UnityEngine;
using Neodroid.Utilities;
using Neodroid.Actors;
using System;

namespace Neodroid.Motors {
  [Serializable]
  public class Motor : MonoBehaviour {
    public bool _debug = false;
    public bool _bidirectional = true;
    public float _energy_cost = 1;
    protected float _energy_spend_since_reset = 0;
    public Actor _actor_game_object;

    private void Start () {
      RegisterComponent ();
    }

    public virtual void RegisterComponent () {
      _actor_game_object = NeodroidUtilities.MaybeRegisterComponent (_actor_game_object, this);
    }

    private void Update () {
    }

    public Motor () {
    }

    public virtual string GetMotorIdentifier () {
      return name + "Motor";
    }

    public virtual void ApplyMotion (MotorMotion motion) {
    }

    public virtual float GetEnergySpend () {
      return _energy_spend_since_reset;
    }

    public override string ToString () {
      return GetMotorIdentifier ();
    }

    public virtual void Reset () {
      _energy_spend_since_reset = 0;
    }
  }
}
