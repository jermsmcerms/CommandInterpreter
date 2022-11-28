public class CrouchCommand : ICommand {
    public void Execute(Actor actor) {
        actor.UpdateMovmenetState(Actor.MovementState.CROUCH);
    }
}
