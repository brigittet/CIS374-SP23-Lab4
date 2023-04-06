

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter
        {
            get
            {
                return Persons[Count - 1].LastName[0];
            }
        }


        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            var personGroups = new List<PersonGroup>();
            foreach (Person person in persons)
            {
                person.FirstName = person.FirstName.ToLower();
                person.LastName = person.LastName.ToLower();
            }
            persons.Sort();

            // This isn't correct code. 
            // It's is just a sample of how to interact with the classes.
            //var group1 = new PersonGroup();
            //var group2 = new PersonGroup();

            //foreach (var person in persons)
            //{
            //    if (person.FirstName.StartsWith("K"))
            //    {
            //        group1.Persons.Add(person);
            //    }
            //    else
            //    {
            //        group2.Persons.Add(person);
            //    }
            //}

            //personGroups.Add(group1);
            //personGroups.Add(group2);

            //return personGroups;

            var currentGroup = new PersonGroup();
            foreach (Person person in persons)
            {
                if (currentGroup.Persons.Count == 0)
                {
                    currentGroup.Persons.Add(person);
                    continue;
                }
                if (currentGroup[0].Distance(person) <= distance)
                {
                    currentGroup.Persons.Add(person);
                    continue;
                }
                else
                {
                    personGroups.Add(currentGroup);
                    var nextGroup = new PersonGroup();
                    nextGroup.Persons.Add(person);
                    currentGroup = nextGroup;
                }
            }
            return personGroups;
        }

    }
}
