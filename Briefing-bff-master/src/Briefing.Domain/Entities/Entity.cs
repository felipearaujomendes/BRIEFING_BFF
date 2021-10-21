using Briefing.Domain.Messages;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Briefing.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [BsonId]
        public Guid Id { get; private set; }


        //[BsonId]
        //[NotMapped]
        //public string DontUseInAppMongoId
        //{
        //    get { return Id.ToString(); }
        //    set { Id = Guid.Parse(value); }
        //}

        
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }


        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
