using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandToConsole()
        {
            string addMessage = " command has been added to the console.";
            DeveloperConsole.AddCommandsToConsole(Command, this);
            DeveloperConsole.AddMessageToConsole(Name + addMessage);
        }

        public abstract void RunCommand();

    }
}
