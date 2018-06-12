using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;

namespace Kostowski.TeaCatalog.WPFGUI.ViewModels
{
    public class ProducerViewModel : ViewModelBase
    {
        private IProducer _producer;
        public IProducer Producer { get => _producer; }

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }

        [Required(ErrorMessage = "Name has to be specified!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 100 characters long!")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Year has to be specified!")]
        [Range(1, 2018, ErrorMessage = "Year must be between 1 and 2018")]
        public int Founded
        {
            get => _producer.Founded;
            set
            {
                _producer.Founded = value;
                Validate();
                OnPropertyChanged("Founded");
            }
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
