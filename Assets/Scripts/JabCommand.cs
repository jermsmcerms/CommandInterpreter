using UnityEngine;

public class JabCommand : ICommand {
    public void Execute(Actor actor) {
        switch (actor.MovmentState) {
            case Actor.MovementState.JUMP:
                Debug.Log("jumping jab");
                break;
            case Actor.MovementState.STAND:
                Debug.Log("standing jab");
                break;
            case Actor.MovementState.CROUCH:
                Debug.Log("crouching jab");
                break;
        }
    }
}
