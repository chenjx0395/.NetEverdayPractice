using CardSystem;

ICard card1 = new ChenCard();
ICard card2 = new LiBuyCard();

ICardReader reader1 = new ChenCardReader();

try{
reader1.ReaderCard(card1);
reader1.ReaderCard(card2);
}
catch (Exception ex)
{
  Console.WriteLine(ex.ToString());
}
