namespace WebService.ViewModels.Resposne
{
    public class MessageDto : BaseDto
    {
        public int Text { get; set; }
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
