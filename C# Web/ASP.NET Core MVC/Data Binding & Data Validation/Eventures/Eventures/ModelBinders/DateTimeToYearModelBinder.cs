using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Eventures.ModelBinders
{
    public class DateTimeToYearModelBinderProvider : IModelBinderProvider
    {
        //Global binder for model entity, must be registred in services.AddMvc
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(DateTime)
                && context.Metadata.Name == "Start" || context.Metadata.Name == "End")
            {
                return new DateTimeToYearModelBinder();
            }

            return null;
        }
    }

    public class DateTimeToYearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Takes value of property
            var httpYear = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);// ModelName is property name

            if (DateTime.TryParse(httpYear.FirstValue, out var dateTime))
            {
                bindingContext.Result = ModelBindingResult.Success(dateTime.Year);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
