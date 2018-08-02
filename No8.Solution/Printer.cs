using System;
using System.IO;

namespace No8.Solution
{
    public sealed class Printer: IEquatable<Printer>
    {
        #region Private fields
        private string name;
        private string model;
        #endregion

        #region .Ctors
        public Printer(string name, string model)
        {
            Name = name;
            ValidateNullOrEmpty(model);
            Model = model;
        }
        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set
            {
                ValidateNullOrEmpty(value);
                name = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                ValidateNullOrEmpty(value);
                model = value;
            }
        }

        #endregion

        #region Public API

        public void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

        public bool Equals(Printer other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.Name == other.Name && this.Model == other.Model)
            {
                return true;
            }

            return false;
        }

        public void Register(PrinterManager manager) => manager.OutputTerminator += ShowMessage;

        public void Unregister(PrinterManager manager) => manager.OutputTerminator -= ShowMessage;

        public void ShowMessage(object sender, TerminatorEventArgs e) => Console.WriteLine(e.Message);

        #endregion

        #region Private methods

        private void ValidateNullOrEmpty(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value == string.Empty)
            {
                throw new ArgumentException(nameof(value));
            }
        }      

        #endregion
    }
}