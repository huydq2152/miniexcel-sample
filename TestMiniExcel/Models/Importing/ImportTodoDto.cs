namespace TestMiniExcel.Models.Importing;

public class ImportTodoDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public bool IsComplete { get; set; }

    /// <summary>
    /// Can be set when reading data from Excel or when importing user
    /// </summary>
    public string Exception { get; set; }

    public bool CanBeImported()
    {
        return string.IsNullOrEmpty(Exception);
    }
}