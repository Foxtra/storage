namespace Storage.Interfaces;
internal interface IOutput
{
    public void WriteString(string stringToOutput);

    public void WriteList<T>(List<T> ListToOutput);

    public void WriteEmptyLine();
}
