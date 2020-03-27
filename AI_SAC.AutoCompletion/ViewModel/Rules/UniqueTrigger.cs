using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace AI_SAC.AutoCompletion.ViewModel.Rules
{
    public class UniqueTrigger : ValidationRule
    {
        public CollectionViewSource CurrentCollection { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                ObservableCollection<DataItemViewModel> castedCollection = (ObservableCollection<DataItemViewModel>)CurrentCollection.Source;

                DataItemViewModel curValue = (DataItemViewModel)((BindingExpression)value).DataItem;

                if(curValue.Trigger.Length < 3)
                    return new ValidationResult(false, $"Can not have an item with trigger that has less than 3 characters.");

                foreach (DataItemViewModel divm in castedCollection)
                {
                    if (String.IsNullOrEmpty(divm.Trigger))
                        continue;
                    if (curValue.GetHashCode() != divm.GetHashCode() && (divm.Trigger.ToLower().Contains(curValue.Trigger.ToLower()) || curValue.Trigger.ToLower().Contains(divm.Trigger.ToLower())))
                    {
                        return new ValidationResult(false, $"Can not have two items where one trigger contains the other.");
                    }
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
