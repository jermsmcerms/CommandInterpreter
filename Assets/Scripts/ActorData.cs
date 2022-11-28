using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActorData : ScriptableObject
{
    public CommandDataConatainer commandsContainer;

    public Dictionary<InputType, ICommand> Commands { get { return m_commands; } }
    private Dictionary<InputType, ICommand> m_commands;

    public void InitializeCommands() {
        m_commands = new();
        if (commandsContainer != null) {
            // Some commands are performed by pressing two or more buttons simultaniously.
            // OR them together such that we only need one enum value per command.
            foreach (CommandData commandData in commandsContainer.commands) {
                InputType commandInput = InputType.NONE;
                foreach (var input in commandData.inputs) {
                    commandInput |= input;
                }

                ICommand command = CommandFactory.CreateCommand(commandInput);
                if (command != null) {
                    m_commands.Add(commandInput, command);
                } else {
                    Debug.LogError("Class not found for command: " + commandInput + "!");
                }
            }
        }
    }
}
