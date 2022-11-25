using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCommand : ICommand {
    public void Execute(Actor actor) {
        Debug.Log("punch throw");
    }
}
