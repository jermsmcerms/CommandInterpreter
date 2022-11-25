using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : ICommand {
    public void Execute(Actor actor) {
        actor.UpdateMovmenetState(Actor.MovementState.CROUCH);
    }
}
