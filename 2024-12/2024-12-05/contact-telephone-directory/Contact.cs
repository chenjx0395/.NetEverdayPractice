namespace ContactSystem {
  public class Contact{
    public string Name { set; get; }
    public string Phone { set;  get;}

   
    public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}