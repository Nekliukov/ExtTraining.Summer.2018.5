using System;

namespace No8.Solution
{
    public class TerminatorEventArgs : EventArgs
    {
        private string message;

        public TerminatorEventArgs(string message)
        {
            Message = message;
        }

        public string Message
        {
            get => message;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(nameof(value));
                }

                message = value;
            }
        }
    }
}