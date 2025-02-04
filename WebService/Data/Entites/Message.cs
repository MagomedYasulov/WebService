namespace WebService.Data.Entites
{
    public class Message : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
