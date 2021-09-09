using System;

namespace Events
{
    public class FileArgs : EventArgs
    {
        public string FileName { get; init; }
    }
}