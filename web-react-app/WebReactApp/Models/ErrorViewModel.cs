using System.Collections.Generic;

namespace WebReactApp.Models
{
    public class ErrorViewModel
    {
        public string Exception { get; set; }
        public string Path { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public bool Gender { get; set; }

        public IEnumerable<EntityField> GetFields()
        {
            return new List<EntityField>
            {
                new EntityField
                {
                    Code = nameof(Name),
                    Value = "1"
                }
            };
        }
    }

    public class Entity
    {
        public IEnumerable<EntityField> Fields { get; set; }
    }

    public class EntityField
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
