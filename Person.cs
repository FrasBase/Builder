using System;

namespace Builder.Persons
{
    public class Person
    {
        public string StreetAddress, Postcode, City;

        //job info
        public string CompanyName, Position;
        public int AnnualIncome;
        
        public override string ToString()
        {
            return string.Format("StreetAddress: {0}, Postcode: {1}, City: {2}, CompanyName: {3}, Position: {4}, AnnualIncome: {5}",StreetAddress, Postcode, City, CompanyName, Position, AnnualIncome);
        }
    }

    public class PersonBuilder
    {
        //building object
        protected Person person; //referrence
        public PersonBuilder() => person = new Person();
        protected PersonBuilder(Person person) => this.person = person;
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) : base(person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress=streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person) : base(person)
        {
            this.person=person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    }
}