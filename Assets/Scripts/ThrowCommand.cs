using UnityEngine;

public class ThrowCommand : ICommand {
    public void Execute(Actor actor) {
        Debug.Log("punch throw");
    }
}
