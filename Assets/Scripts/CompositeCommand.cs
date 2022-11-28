using System.Collections.Generic;

public class CompositeCommand : ICommand {
    public List<ICommand> commands = new();

    public void AddChildren(ICommand command) {
        commands.Add(command);
    }

    public void Execute(Actor actor) {
        // This is pretty crude, but the idea is that when there are no commands
        // to execute, assume the actor is standing on the ground.
        if(commands.Count <= 0) {
            actor.UpdateMovmenetState(Actor.MovementState.STAND);
        }

        foreach (ICommand command in commands) {
            command.Execute(actor);
        }

        // We may only need one instance of a commposite command so for now
        // clear the composition.
        commands.Clear();
    }
}
