namespace CadastroDeVeiculos.Domain.ValueObject
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string Lastname { get; private set; }

        protected Name() { }

        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
        }
    }
}
