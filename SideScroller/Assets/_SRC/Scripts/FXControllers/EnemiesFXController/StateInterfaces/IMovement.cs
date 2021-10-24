using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void IsMoving(bool _IsMoving);
    public void Move(float _speed);
}
