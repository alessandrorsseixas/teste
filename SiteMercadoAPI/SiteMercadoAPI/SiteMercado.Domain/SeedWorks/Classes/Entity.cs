using FluentValidation;
using FluentValidation.Results;
using SiteMercado.Domain.SeedWorks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiteMercado.Domain.SeedWorks.Classes
{
    public abstract class Entity
    {
        private int? _requestedHashCode;

        [Key]
        public int Id { get; set; }
        public Guid Code { get; set; }


        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public String UpdatedUser { get; set; }

        [NotMapped]
        public INotificator _notificator { get; set; }

        public List<Notification> GetNotifications()
        {

            return _notificator.GetNotifications();
        }



        public void NotificationDomainEvent(string eventITem)
        {
            _notificator.Handle(new Notification(eventITem));
        }

        public void NotificationDomainEvent(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotificationDomainEvent(error.ErrorMessage);
            }
        }


        public bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            NotificationDomainEvent(validator);

            return false;
        }


        public void SetNotificator(INotificator notificator)
        {
            _notificator = notificator;

        }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            //if (item.IsTransient() || this.IsTransient())
            //    return false;
            //else
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
