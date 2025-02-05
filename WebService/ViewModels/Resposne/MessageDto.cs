namespace WebService.ViewModels.Resposne
{
    public class MessageDto : BaseDto
    {
        public string Text { get; set; } = string.Empty;
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
