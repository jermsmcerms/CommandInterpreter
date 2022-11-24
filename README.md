# CommandInterpreter
A fixed timestep based command interpreter
Inputs are read into a circular buffer and then translated into
commands that are defined by SerializableObject scripts and
instantiated via an object factory.

The command interpreter takes the inputs from the buffer
and if there are any inputs that exist in the command dictionary,
the command is added to a CompositeCommand class that executes
1 or more separate commands durring the current frame.

When it is time to execute the composite command, each command in its
list of commands are executed in FIFO order. 

If you want to use this in your own game, ideally you'd want to
only update your character on screen after the last command is executed.
Commands can change an actors internal state(s), but what happens at the end
of the frame should be determined by your last executed command.

For example, in this demo, pressing 's' on the keyboard puts the Actor
into a "crouching" state. When 'u' is pressed, the Actor perfroms a "jab"
action. Which type of jab depends on their grounded state, JUMPING,
STANDING, or CROUCHING. When 's' and 'u' are added to the buffer on
the same frame then, the crouching command is executed first, then
the jab command. Thus, the actor performs a "crouching jab" attack.

I plan on using this as the basis for my fighting game. Although,
I plan on adding more features to this such as blocking executions
durring certain actor actions and allowing for buffered input that
allows for special motion inputs found in classic fighting games
such as Street Fighter. Although, I will not be adding that code here.
I will let you try and figure that out for yourself :)
