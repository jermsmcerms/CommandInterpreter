using System;
using System.Collections.Generic;

public class CommandInterpreter {
    private readonly CompositeCommand m_compositeCommands;
    private readonly Dictionary<InputType, ICommand> m_commands;

    public CommandInterpreter(Dictionary<InputType, ICommand> commands) {
        m_commands = commands;
        m_compositeCommands = new CompositeCommand();
    }

    public void ExcecuteCommands(Actor actor) {
        m_compositeCommands.Execute(actor);
    }

    public void ComposeCommands(InputType currentInput) {
        // Input deconstruction works by extracting the largest 2^n number
        // from the currentInput until all that is left are directional inputs.
        InputType finalAttackInput = InputType.NONE;
        while(currentInput > InputType.LEFT) {
            int msb = (int)(MathF.Log((int)currentInput) / MathF.Log(2));

            int largestBase2Exponent = 1 << msb;
            currentInput -= largestBase2Exponent;
            // Recombine the attack inputs
            finalAttackInput |= (InputType)largestBase2Exponent;
        }

        // After extracting all attack buttons, all that is left from the
        // original input should be directional inputs, or zero.
        if (m_commands.ContainsKey(currentInput)) {
            m_compositeCommands.AddChildren(m_commands[currentInput]);
        }


        if (m_commands.ContainsKey(finalAttackInput)) {
            m_compositeCommands.AddChildren(m_commands[finalAttackInput]);
        }
    }
}
