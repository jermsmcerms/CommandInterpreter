using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandFactory {
    public static ICommand CreateCommand(InputType input) {
        return input switch {
            InputType.DOWN => new CrouchCommand(),
            InputType.JAB => new JabCommand(),
            InputType.JAB | InputType.STRONG => new ThrowCommand(),
            _ => null
        };
    }
}
