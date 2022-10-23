using System.ComponentModel.DataAnnotations;

namespace Povio.FlowerSpot.Infrastructure.Configurations
{
    public class QuoteServiceConfiguration
    {
        public const string Position = "QuoteService";

        [Required]
        public string BaseUrl { get; set; }
    }
}