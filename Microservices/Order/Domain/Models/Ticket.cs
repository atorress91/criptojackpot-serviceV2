using CryptoJackpot.Domain.Core.Models;
using CryptoJackpot.Order.Domain.Enums;

namespace CryptoJackpot.Order.Domain.Models;

/// <summary>
/// Representa la compra de un ticket de lotería.
/// </summary>
public class Ticket : BaseEntity
{
    public Guid TicketGuid { get; set; }
    public Guid LotteryId { get; set; }
    public long UserId { get; set; }

    public decimal PurchaseAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public TicketStatus Status { get; set; }
    public string TransactionId { get; set; } = null!;
    public bool IsGift { get; set; }
    public long? GiftRecipientId { get; set; }
    public int[] SelectedNumbers { get; set; } = null!;
    public int Series { get; set; }
    public List<long>? WonPrizeIds { get; set; }
}