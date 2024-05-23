using Task2.constant;

namespace Task2.model;

/// <summary>
/// A value object used to represent an movie price. 
/// </summary>
/// <param name="Price">A <see cref="double"/></param>
/// <param name="AgeGroup">A <see cref="MovieAgeGroup"/></param>
internal record class MoviePrice(
    double Price,
    MovieAgeGroup AgeGroup
);
