namespace zadanie2.Models;

class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}