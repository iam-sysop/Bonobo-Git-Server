using gitserverdotnet.App_GlobalResources;
using gitserverdotnet.Data;
using gitserverdotnet.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace gitserverdotnet.Attributes
{
    public class UniqueRepoNameAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("empty repo name?");
            }

            IRepositoryRepository RepositoryRepository = DependencyResolver.Current.GetService<IRepositoryRepository>();
            if (RepositoryRepository.NameIsUnique(value.ToString(), ((RepositoryDetailModel)context.ObjectInstance).Id))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(Resources.Validation_Duplicate_Name);
        }
    }
}