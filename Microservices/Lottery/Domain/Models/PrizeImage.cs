namespace CryptoJackpot.Lottery.Domain.Models;

public class PrizeImage
{
    public Guid Id { get; set; }
    public Guid PrizeId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Caption { get; set; } = null!;
    public int DisplayOrder { get; set; }

    public virtual Prize Prize { get; set; } = null!;
}