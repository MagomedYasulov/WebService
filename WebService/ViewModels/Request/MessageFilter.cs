using Microsoft.AspNetCore.Mvc;

namespace WebService.ViewModels.Request
{
    public class MessageFilter
    {
        [FromQuery]
        public DateTime? StartTime { get; set; }
        [FromQuery]
        public DateTime? EndTime { get; set; }
    }
}
