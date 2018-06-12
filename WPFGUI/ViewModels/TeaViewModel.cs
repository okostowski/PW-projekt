using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kostowski.TeaCatalog.Interfaces;
using Kostowski.TeaCatalog.Core;

namespace Kostowski.TeaCatalog.WPFGUI.ViewModels
{
    public class TeaViewModel : ViewModelBase
    {
        private IProduct _tea;
        public IProduct Tea { get => _tea; }

        public TeaViewModel(IProduct tea, List<IProducer> listProducers)
        {
            _tea = tea;
            _producers = new ObservableCollection<IProducer>(listProducers);
        }

        [Required(ErrorMessage = "Name has to be specified!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 100 characters long!")]
        public string Name
        {
            get => _tea.Name;
            set
            {
                _tea.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Color has to be specified!")]
        public Color Color
        {
            get => _tea.Color;
            set
            {
                _tea.Color = value;
                Validate();
                OnPropertyChanged("Color");
            }
        }

        [Required(ErrorMessage = "Producer has to be specified!")]
        public IProducer Producer
        {
            get => _tea.Producer;
            set
            {
                _tea.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }

        private ObservableCollection<IProducer> _producers;

        public ObservableCollection<IProducer> Producers
        {
            get => _producers;
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
