namespace CardSystem
{
  public class ChenCardReader : ICardReader
  {
    public Dictionary<string, string> SupportedCards = [];

    public ChenCardReader()
    {
      ICard card1 = new ChenCard();
      SupportedCards.Add(card1.configuration, card1.name);
    }

    // 读卡功能
    public void ReaderCard(ICard card)
    {
      //判断插入的卡片是否支持
      if (SupportedCards.ContainsKey(card.configuration))
      {
        Console.WriteLine($"读卡成功,卡片名称: {card.name}");
      }
      else
      {
        throw new Exception("此卡片不支持");
      }
    }


  }
}