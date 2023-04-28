namespace mis_221_pa_5_jsmorris5
{
    public class Trainer{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Trainer(string id, string name, string address, string email){
        Id = id;
        Name = name;
        Address = address;
        Email = email;
        }

        public override string ToString(){
        return $"{Id}#{Name}#{Address}#{Email}";
        }

    }
}