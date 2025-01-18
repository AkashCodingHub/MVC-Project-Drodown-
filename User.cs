using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FetchCeudDependices.Models
{
    public class User
    {
        public int Id { get; set; }

        public List<User> MyUsers { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid country.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        public string CountryName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid state.")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        public string StateIName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid city.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        public string CityName { get; set; }

     
    }

    public class Country
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        public string CountryName { get; set; }
    }

    public class State
    {
        public int StateId { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        public string StateIName { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        public string CityName { get; set; }
    }
}
