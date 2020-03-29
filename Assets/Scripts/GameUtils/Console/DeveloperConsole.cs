using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;
using UnityEngine.UI;

namespace Console
{
    public class DeveloperConsole : SingletonObject<DeveloperConsole>
    {
        [Header("UI Components")]
        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public Text consoleText;
        public Text inputText;
        public InputField consoleInput;

        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        void Awake()
        {
            Commands = new Dictionary<string, ConsoleCommand>();
        }

        private void Start()
        {
            Instance.consoleInput.Select();
            CreateCommands();
        }

        private void CreateCommands()
        {
            CommandQuit commandQuit = CommandQuit.CreateCommand();
        }
                
        private void ParseInput(string _input)
        {
            string[] temp = _input.Split(null);

            if (temp.Length == 0 || temp == null)
            {
                AddMessageToConsole("Command not recognized.");
                Instance.consoleInput.text = string.Empty;
                return;
            }

            if (!Commands.ContainsKey(temp[0]))
            {
                AddMessageToConsole("Command not recognized.");
                Instance.consoleInput.text = string.Empty;
            }
            else
            {
                Commands[temp[0]].RunCommand();
                Instance.consoleInput.text = string.Empty;
            }
        }
        
        private void Update()
        {
            if (consoleCanvas.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ParseInput(inputText.text);
                }
            }
        }

        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if (!Commands.ContainsKey(_name))
            {
                Commands.Add(_name, _command);
            }
        }

        public static void AddMessageToConsole(string _msg)
        {
            Instance.consoleText.text += _msg + "\n";
            Instance.scrollRect.verticalNormalizedPosition = 0f;
        }

    }
}