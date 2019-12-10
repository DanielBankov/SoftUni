using System;
using System.Collections.Generic;
using System.Linq;

namespace Oldest_Family_Member
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public void AddMember(Person member)
        {
            if(member == null)
            {
                throw new Exception();
            }

            this.Members.Add(member);
        }

        public Person GetOldestPerson()
        {
            return this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
