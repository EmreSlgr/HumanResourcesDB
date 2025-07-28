public class DocumentItem
{
    public int DocumentID { get; set; }
    public string DocumentName { get; set; }
    public string FileType { get; set; }  

    public override string ToString()
    {
        return DocumentName;
    }
}
